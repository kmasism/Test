using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Helpers;
using UpgradeStubs;

namespace JETNET_Homebase
{
	internal static class modAsync
	{

		// ====================================================================================
		// Written By : David D. Cruger
		// Created    : 06/22/2006
		// Modified   : 06/22/2006
		// Module     : modAsync
		//
		// Notes      : This creates and Array of Async Connection Objects for Submitting
		// Stored Procedures Asynchronously.  Starts by creating an Array of ADODB Connection
		// Objects (4 elements) Will Expand if more are needed.
		// Will scan and find an un-used Object, opens the connection and executes the
		// Stored Procedure.  Must Call InitializeAsyncConnectionArray before submitting
		// any Stored Procedures and must Call CloseAllAsyncConnections to close and destory
		// the connection objects when done. The close routine will wait for any Stored Procedures
		// that are still executing.
		//
		// ====================================================================================


		private static DbConnection[] gconnAsync = null;
		private static bool bHasAsyncConnectionArrayBeenInitialized = false;

		internal static void InitializeAsyncConnectionArray()
		{

			if (!bHasAsyncConnectionArrayBeenInitialized)
			{
				gconnAsync = new DbConnection[5]; // Start With 4 But It Will Expand If Needed
				bHasAsyncConnectionArrayBeenInitialized = true;
			}

		} // End Sub InitializeAsyncConnectionArray

		internal static void SubmitAsyncStoredProcedure(string strConnectionString, string strStoredProcedure)
		{

			int iCnt = 0;

			Exception ex = null; // Just Continue

			bool bFoundConnection = false;
			int iTotal = 0;
			ErrorHandlingHelper.ResumeNext(out ex);

			if (!bHasAsyncConnectionArrayBeenInitialized)
			{
				ErrorHandlingHelper.ResumeNext(out ex, 
					() => {InitializeAsyncConnectionArray();});
			}
			ErrorHandlingHelper.ResumeNext(out ex, 

				() => {iTotal = gconnAsync.GetUpperBound(0);}); // Number Of Connetions Available

			//----- Any Connection Objects in the Array?
			if (iTotal > 0)
			{
				ErrorHandlingHelper.ResumeNext(out ex, 

						//------- Find an Un-Used Connection Object ------
					() => {iCnt = -1;});

				do 
				{
					ErrorHandlingHelper.ResumeNext(out ex,  // Loop Until (iCnt >= iTotal - 1) Or (bFoundConnection = True)

						() => {iCnt++;});
					if (gconnAsync[iCnt] == null)
					{
						ErrorHandlingHelper.ResumeNext(out ex,  // Found Un-Used Connection
							() => {bFoundConnection = true;}, 
							() => {gconnAsync[iCnt] = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();}); // Create Object
					}
					else
					{
						ErrorHandlingHelper.ResumeNext(out ex);
						// Check Connection To See If It's Busy

						if ((((int) gconnAsync[iCnt].State) & ((int) ConnectionState.Open)) == ((int) ConnectionState.Open))
						{
							ErrorHandlingHelper.ResumeNext(out ex);

							if ((((int) gconnAsync[iCnt].State) & ((int) ConnectionState.Executing)) == ((int) ConnectionState.Executing))
							{
								ErrorHandlingHelper.ResumeNext(out ex,  // Skip
									() => {Application.DoEvents();});
							}
							else
							{
								ErrorHandlingHelper.ResumeNext(out ex, 
										// Ok to Close and Destory
									() => {UpgradeHelpers.DB.TransactionManager.DeEnlist(gconnAsync[iCnt]);}, 
									() => {gconnAsync[iCnt].Close();});
								bFoundConnection = true;
							}
							ErrorHandlingHelper.ResumeNext(out ex);

						}
						else
						{
							ErrorHandlingHelper.ResumeNext(out ex);
							// Found Un-Used Connection
							bFoundConnection = true;
						}
						ErrorHandlingHelper.ResumeNext(out ex); // adStateOpen

					}
					ErrorHandlingHelper.ResumeNext(out ex); // Is Nothing

				}
				while(!((iCnt >= iTotal - 1) || (bFoundConnection)));
				ErrorHandlingHelper.ResumeNext(out ex);

			}
			ErrorHandlingHelper.ResumeNext(out ex); // If iTotal > 0 Then

			//------ If No Connection Objects Available Or None Exist Add A New One
			if (!bFoundConnection)
			{
				ErrorHandlingHelper.ResumeNext(out ex,  // Add Another Connection Object To The Array
					() => {iTotal++;}, 
					() => {iCnt = iTotal - 1;}, 
					() => {gconnAsync = ArraysHelper.RedimPreserve(gconnAsync, new int[]{iTotal + 1});}, 
					() => {gconnAsync[iCnt] = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();}); // Create Object
			}
			ErrorHandlingHelper.ResumeNext(out ex, 

					//------- Now Open The Connection and Execute The Stored Procedure Async
					//UPGRADE_ISSUE: (2064) ADODB.Connection property gconnAsync.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				() => {gconnAsync[iCnt].setCursorLocation(CursorLocationEnum.adUseServer);}, 
				() => {UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(gconnAsync[iCnt], 300);},  // 5 Minutes
					//UPGRADE_TODO: (7010) The connection string must be verified to fullfill the .NET data provider connection string requirements. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-7010
				() => {gconnAsync[iCnt].ConnectionString = strConnectionString;}, 
				() => {gconnAsync[iCnt].Open();});

			if (ex == null)
			{
				DbCommand TempCommand = null;
				ErrorHandlingHelper.ResumeNext( // Continue - No Errors So Far
					() => {TempCommand = gconnAsync[iCnt].CreateCommand();}, 
					() => {UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);}, 
					() => {TempCommand.CommandText = strStoredProcedure;}, 
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adAsyncExecute was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					() => {TempCommand.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadAsyncExecute()) + ((int) CommandType.Text));}, 
					() => {UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);}, 
					() => {TempCommand.ExecuteNonQuery();});
			}

		} // End Sub SubmitAsyncStoredProcedure


		internal static void CloseAllAsyncConnections()
		{

			int iTotal = 0; // Number Of Connetions Available
			int iCnt = 0;
			 // Just Continue

			if (bHasAsyncConnectionArrayBeenInitialized)
			{
				try
				{

					iTotal = gconnAsync.GetUpperBound(0);

					//----- Any Connection Objects in the Array?
				}
				catch
				{
				}
				if (iTotal > 0)
				{
					try
					{

						//------- Find and UnUsed Connection Object ------
						iCnt = -1;
					}
					catch
					{
					}

					do 
					{
						try
						{ // Loop Until (iCnt >= iTotal - 1)

							iCnt++;
						}
						catch
						{
						}

						if (gconnAsync[iCnt] != null)
						{ // Found Created Object

							if ((((int) gconnAsync[iCnt].State) & ((int) ConnectionState.Open)) == ((int) ConnectionState.Open))
							{ // Found Open Connection

								if ((((int) gconnAsync[iCnt].State) & ((int) ConnectionState.Executing)) == ((int) ConnectionState.Executing))
								{ // Wait Until Execution Has Completed

									// Wait Until Execution Has Completed Before Closing And Destorying

									while((((int) gconnAsync[iCnt].State) & ((int) ConnectionState.Executing)) == ((int) ConnectionState.Executing))
									{
										try
										{ //<- While trying to execute
											Application.DoEvents();
										}
										catch
										{
										}
									};
								}
								ErrorHandlingHelper.ResumeNext(

										// Ok to Close Now
									() => {UpgradeHelpers.DB.TransactionManager.DeEnlist(gconnAsync[iCnt]);}, 
									() => {gconnAsync[iCnt].Close();});

							}
							try
							{ // adStateOpen

								// Ok To Destory Now
								gconnAsync[iCnt] = null;
							}
							catch
							{
							}

						} // Is Nothing

					}
					while(!(iCnt >= iTotal - 1));

				} // If iTotal > 0 Then

			} // If bHasAsyncConnectionArrayBeenInitialized = True Then

		} // CloseAllAsyncConnections


		internal static void CloseAllAsyncConnectionsNotInUse()
		{

			int iTotal = 0; // Number Of Connetions Available
			int iCnt = 0;
			 // Just Continue

			if (bHasAsyncConnectionArrayBeenInitialized)
			{
				try
				{

					iTotal = gconnAsync.GetUpperBound(0);

					//----- Any Connection Objects in the Array?
				}
				catch
				{
				}
				if (iTotal > 0)
				{
					try
					{

						//------- Find and UnUsed Connection Object ------
						iCnt = -1;
					}
					catch
					{
					}

					do 
					{
						try
						{ // Loop Until (iCnt >= iTotal - 1)

							iCnt++;
						}
						catch
						{
						}

						if (gconnAsync[iCnt] != null)
						{ // Found Created Object

							if ((((int) gconnAsync[iCnt].State) & ((int) ConnectionState.Open)) == ((int) ConnectionState.Open))
							{ // Found Open Connection

								if ((((int) gconnAsync[iCnt].State) & ((int) ConnectionState.Executing)) == ((int) ConnectionState.Executing))
								{
									try
									{ // Skip
										Application.DoEvents();
									}
									catch
									{
									}
								}
								else
								{
									ErrorHandlingHelper.ResumeNext(
											// Ok to Close and Destory
										() => {UpgradeHelpers.DB.TransactionManager.DeEnlist(gconnAsync[iCnt]);}, 
										() => {gconnAsync[iCnt].Close();});
									gconnAsync[iCnt] = null;
								}

							}
							else
							{
								// Ok to Destory
								gconnAsync[iCnt] = null;
							} // adStateOpen

						} // Is Nothing

					}
					while(!(iCnt >= iTotal - 1));

				} // If iTotal > 0 Then

			} // If bHasAsyncConnectionArrayBeenInitialized = True Then

		} // CloseAllAsyncConnectionsNotInUse
	}
}