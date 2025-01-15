using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Windows.Forms;
using UpgradeHelpers.Helpers;

namespace JETNET_Homebase
{
	internal static class modImage
	{


		private static void CalReSize(int iMax, ref int iWidth, ref int iHeight, ref bool bWasResized)
		{


			double dAspect = 0d;
			int iW = 0;
			int iH = 0;

			bWasResized = false;

			if (iWidth > iHeight)
			{

				if (iWidth > iMax)
				{
					dAspect = iWidth / ((double) iMax);
					iW = iMax;
					iH = iHeight / Convert.ToInt32(dAspect);
				}

			}
			else
			{

				if (iHeight > iMax)
				{
					dAspect = iHeight / ((double) iMax);
					iH = iMax;
					iW = iWidth / Convert.ToInt32(dAspect);
				}

			} // If iWidth > iHeight Then

			if ((dAspect != 0d) && (iW != 0) && (iH != 0))
			{
				iWidth = iW;
				iHeight = iH;
				bWasResized = true;
			}

		} // CalReSize

		// 03/25/2014 - By David D. Cruger
		// Added Error Checking

		internal static bool CopyImageFromToAndReSize(string strFromFileName, string strToFileName, string strType, int iMax, bool bResize, bool bOverWrite)
		{

			bool result = false;
			dynamic pImage = null; //gap-note control must be reviewed during blazor stabilization //PTRUE2.PhotoObject pImage = new PTRUE2.PhotoObject(); // [x] PhotoTrue v2

			string strFileName = "";
			bool bResults = false;
			bool bWasResized = false;
			int iWidth = 0;
			int iHeight = 0;
			string strErrDesc = "";
			string strMsg = "";

			try
			{

				bResults = false;

				if (File.Exists(strFromFileName))
				{

					strFileName = strFromFileName;

					strType = strType.ToUpper();
					switch(strType)
					{
						case "JPG" : 
							pImage.CreateFromJPGFile(strFromFileName); 
							break;
						case "BMP" : 
							pImage.CreateFromBMPFile(strFromFileName); 
							break;
					}

					iWidth = pImage.Width;
					iHeight = pImage.Height;

					if (bResize)
					{
						CalReSize(iMax, ref iWidth, ref iHeight, ref bWasResized);
						if (bWasResized)
						{
							pImage.Resize(iWidth, iHeight);
						}
					} // If bResize = True Then

					//UPGRADE_WARNING: (2099) Return value for Dir has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2099
					strFileName = FileSystem.Dir(strToFileName);

					if ((bOverWrite && strFileName == "") || (!bOverWrite))
					{
						pImage.SaveAsJPGFile(strToFileName, 95, false, false, true); // changed to 95 . MSW - 1/14/18, was previously 90
						bResults = true;
					}

					pImage.Clear();

				} // If gfso.FileExists(strFromFileName) = True Then

				pImage = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				strErrDesc = excep.Message;
				strMsg = $"CopyImageFromToAndReSize_Error: {strErrDesc}";
				modAdminCommon.Record_Error("CopyImage", strMsg);
				MessageBox.Show(strMsg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);

				result = false;
			}
			return result;
		} // CopyImageFromToAndReSize
	}
}