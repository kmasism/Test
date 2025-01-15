// <copyright file="ADORecordSetSerializer.cs" company="Growth Acceleration Partners, LLC">
//       Copyright © 2024 Growth Acceleration Partners, LLC. All Rights Reserved,
//       All classes are provided for customer use only,
//       all other use is prohibited without prior written consent from Growth Acceleration Partners, LLC,
//       no warranty express or implied,
//       use at own risk.
// </copyright>

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters;
using System.Text;

namespace UpgradeHelpers.DB
{
    /// <summary>
    /// Converts a <see cref="DataSet"/> to and from JSON.
    /// </summary>
    public class ADORecordSetSerializer
    {
        /// <summary>
        /// Returns new AdoRecordSetObject
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public T DeSerializeObject<T>(string value)
        {
            StringReader stringReader = new StringReader(value);
            JsonReader reader = new JsonTextReader(stringReader);
            JsonSerializer serializer = new JsonSerializer() { Formatting = Formatting.Indented };
            return (T)this.ReadJson(reader, typeof(T), null, serializer);
        }

        /// <summary>
        /// Serialize AdoRecordSetObject
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string SerializeObject<T>(object value)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            JsonWriter writer = new JsonTextWriter(sw);
            JsonSerializer serializer = new JsonSerializer() { Formatting = Formatting.Indented };
            this.WriteJson<T>(writer, value, serializer);
            return sw.ToString();
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        internal object ReadJson(JsonReader reader, Type objectType, object existingValue = null, JsonSerializer serializer = null)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            // handle typed datasets
            var ds = Activator.CreateInstance(objectType);

            DataTableConverter converter = new DataTableConverter();
            reader.SupportMultipleContent = true;

            while (reader.Read() && reader.TokenType != JsonToken.StartArray) ;

            int position = 0;

            Type type = ds.GetType();
            PropertyInfo propertyInfo = default(PropertyInfo);
            FieldInfo fieldInfo = default(FieldInfo);

            while (reader.Read() && reader.TokenType != JsonToken.EndArray)
            {
                if (reader.TokenType == JsonToken.PropertyName)
                {
                    if (reader.Path.IndexOf("[0") >= 0)
                    {
                        var tableName = (string)reader.Value;
                        DataTable dt = ((DataSet)ds).Tables[tableName];
                        bool exists = (dt != null);

                        dt = (DataTable)converter.ReadJson(reader, typeof(DataTable), dt, serializer);

                        reader.Read();

                        if (reader.Value.Equals("ColumnMetaData"))
                        {

                            reader.Read();

                            var columnDataTypes = JsonConvert.DeserializeObject<string[]>((string)reader.Value);

                            var columnIndex = 0;

                            var clonedDataTable = dt.Clone();

                            var conflictedTypes = new string[] { "System.Int16", "System.Int32", "System.Int64", "System.DateTime" };

                            foreach (var colDataType in columnDataTypes)
                            {
                                if (conflictedTypes.Contains(colDataType))
                                {
                                    var currentColumn = clonedDataTable.Columns[columnIndex];
                                    clonedDataTable.Columns.RemoveAt(columnIndex);

                                    currentColumn.DataType = Type.GetType(colDataType);

                                    clonedDataTable.Columns.Add(currentColumn);
                                    currentColumn.SetOrdinal(columnIndex);

                                }
                                columnIndex++;
                            }

                            foreach (var row in dt.Rows)
                            {
                                clonedDataTable.Rows.Add(((DataRow)row).ItemArray);
                            }

                            if (!exists)
                            {
                                ((DataSet)ds).Tables.Add(clonedDataTable);
                            }

                            position++;

                        }
                        else
                        {
                            if (!exists)
                            {
                                ((DataSet)ds).Tables.Add(dt);
                            }

                            position++;
                        }
                    }
                    else
                    {
                        propertyInfo = type.GetProperty(reader.Value.ToString());
                        
                        if (propertyInfo == null)
                        {
                            fieldInfo = type.GetField(reader.Value.ToString(), BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                        }
                    }
                }
                else if (reader.Value != null 
                    && (reader.TokenType == JsonToken.Integer 
                    || reader.TokenType == JsonToken.String 
                    || reader.TokenType == JsonToken.Boolean
                    || reader.TokenType == JsonToken.Date
                    || reader.TokenType == JsonToken.Float))
                {

                    switch (reader.TokenType)
                    {
                        case JsonToken.Integer:
                            var intValue = Convert.ToInt32(reader.Value);
                            if (propertyInfo != null)
                            {
                                propertyInfo.SetValue(ds, intValue);
                            }
                            else
                            {
                                fieldInfo.SetValue(ds, intValue);
                            }
                            break;

                        case JsonToken.Float:
                            var floatValue = Convert.ToDouble(reader.Value);
                            if (propertyInfo != null)
                            {
                                propertyInfo.SetValue(ds, floatValue);
                            }
                            else
                            {
                                fieldInfo.SetValue(ds, floatValue);
                            }
                            break;
                        case JsonToken.String:
                            var stringValue = reader.Value;
                            if (propertyInfo != null)
                            {
                                propertyInfo.SetValue(ds, stringValue);
                            }
                            else
                            {
                                fieldInfo.SetValue(ds, stringValue);
                            }
                            break;
                        case JsonToken.Boolean:
                            var booleanValue = Convert.ToBoolean(reader.Value);
                            if (propertyInfo != null)
                            {
                                propertyInfo.SetValue(ds, booleanValue);
                            }
                            else
                            {
                                fieldInfo.SetValue(ds, booleanValue);
                            }
                            break;
                        case JsonToken.Date:
                            var dateValue = Convert.ToDateTime(reader.Value);
                            if (propertyInfo != null)
                            {
                                propertyInfo.SetValue(ds, dateValue);
                            }
                            else
                            {
                                fieldInfo.SetValue(ds, dateValue);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

            return ds;
        }

        private void AssignValueToProperty(PropertyInfo propertyInfo, object ds, object newVal)
        {
            propertyInfo.SetValue(ds, newVal);
        }


        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        internal void WriteJson<T>(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }
            DataSet serializedObject = (DataSet)value;
            DefaultContractResolver resolver = serializer.ContractResolver as DefaultContractResolver;
            DataTableConverter converter = new DataTableConverter();
            writer.WriteStartArray();
            writer.WriteStartObject();
            foreach (DataTable table in serializedObject.Tables)
            {
                writer.WritePropertyName((resolver != null) ? resolver.GetResolvedPropertyName(table.TableName) : table.TableName);
                converter.WriteJson(writer, table, serializer);

                if (table.Columns.Count > 0)
                {
                    writer.WritePropertyName("ColumnMetaData");

                    var json = JsonConvert.SerializeObject(table.Columns.Cast<DataColumn>().Select(x => x.DataType).Select(y => y.FullName).ToArray());

                    writer.WriteValue(json);
                }
                else
                {
                    writer.WritePropertyName("NoColumnMetaData");
                }
            }
            writer.WriteEndObject();
            writer.WriteStartObject();
            Type myClassType = typeof(T);

            // Get all fields of MyClass
            FieldInfo[] fields = myClassType.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            var fieldsWithAttribute = fields.Where(p => p.GetCustomAttribute<JSonSerializeAttribute>() != null);

            foreach (var property in fieldsWithAttribute)
            {
                writer.WritePropertyName(property.Name);
                Type type = serializedObject.GetType();
                FieldInfo fieldInfo = type.GetField(property.Name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                var getJsonVal = fieldInfo.GetValue(serializedObject);
                writer.WriteValue(getJsonVal);
            }

            // Get all properties of MyClass
            PropertyInfo[] properties = myClassType.GetProperties();
            var propertiesWithAttribute = properties.Where(p => p.GetCustomAttribute<JSonSerializeAttribute>() != null);
            foreach (var property in propertiesWithAttribute)
            {
                writer.WritePropertyName(property.Name);
                Type type = serializedObject.GetType();
                PropertyInfo propertyInfo = type.GetProperty(property.Name);
                var getJsonVal = propertyInfo.GetValue(serializedObject);
                writer.WriteValue(getJsonVal);
            }
            writer.WriteEndObject();
            writer.WriteEndArray();
        }
    }
}