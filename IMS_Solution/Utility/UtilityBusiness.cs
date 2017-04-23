using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.Globalization;
using System.IO;
using System.ComponentModel;
using System.Collections;
using System.Drawing;
using System.Collections.Generic;
using System;
using System.Drawing.Imaging;
using System.Windows.Forms;
namespace Utility
{
    public static class UtilityBusiness
    {

        public static string DefaultNoImagePath = AppDomain.CurrentDomain.BaseDirectory + "no_image.jpeg";
        
        public static byte[] GetByteArrayFromFile(string filePath)
        {
            FileStream fs;
            fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            byte[] picbyte = new byte[fs.Length];
            fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            return picbyte;
        }
        public static string WriteByteArrayToFile(byte[] byteArray)
        {
            Random aRandom = new Random();
            string fileName = AppDomain.CurrentDomain.BaseDirectory + "\\tmp\\" + Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + aRandom.Next());
            FileStream fs = new FileStream(fileName,
                                           FileMode.CreateNew, FileAccess.Write);
            fs.Write(byteArray, 0, byteArray.Length);
            fs.Flush();
            fs.Close();
            return fileName;
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static void DeepCopyObjTo(this object S, object T)
        {
            foreach (var pS in S.GetType().GetProperties())
            {
                foreach (var pT in T.GetType().GetProperties())
                {
                    if (pT.Name != pS.Name) continue;
                    (pT.GetSetMethod()).Invoke(T, new object[] { pS.GetGetMethod().Invoke(S, null) });
                }
            };
        }

        public static byte[] CreateThumbnail(byte[] PassedImage, int LargestSide)
        {
            byte[] ReturnedThumbnail;

            using (MemoryStream StartMemoryStream = new MemoryStream(),
                                NewMemoryStream = new MemoryStream())
            {
                // write the string to the stream  
                StartMemoryStream.Write(PassedImage, 0, PassedImage.Length);

                // create the start Bitmap from the MemoryStream that contains the image  
                Bitmap startBitmap = new Bitmap(StartMemoryStream);

                // set thumbnail height and width proportional to the original image.  
                int newHeight;
                int newWidth;
                double HW_ratio;
                if (startBitmap.Height > LargestSide)
                // If the original image isn't larger on any side than LargestSide
                //  then don't increase the size of the image.gestSide || startBitmap.Width > LargestSide)
                {
                    if (startBitmap.Height > startBitmap.Width)
                    {
                        newHeight = LargestSide;
                        HW_ratio = (double)((double)LargestSide / (double)startBitmap.Height);
                        newWidth = (int)(HW_ratio * (double)startBitmap.Width);
                    }
                    else
                    {
                        newWidth = LargestSide;
                        HW_ratio = (double)((double)LargestSide / (double)startBitmap.Width);
                        newHeight = (int)(HW_ratio * (double)startBitmap.Height);
                    }
                }
                else
                {
                    newHeight = startBitmap.Height;
                    newWidth = startBitmap.Width;
                }

                // create a new Bitmap with dimensions for the thumbnail.  
                Bitmap newBitmap = new Bitmap(newWidth, newHeight);

                // Copy the image from the START Bitmap into the NEW Bitmap.  
                // This will create a thumnail size of the same image.  
                newBitmap = ResizeImage(startBitmap, newWidth, newHeight);

                // Save this image to the specified stream in the specified format.  
                newBitmap.Save(NewMemoryStream, ImageFormat.Jpeg);

                // Fill the byte[] for the thumbnail from the new MemoryStream.  
                ReturnedThumbnail = NewMemoryStream.ToArray();
            }

            // return the resized image as a string of bytes.  
            return ReturnedThumbnail;
        }
        public static byte[] CreateThumbnail(byte[] PassedImage, int width, int height)
        {
            byte[] ReturnedThumbnail;

            using (MemoryStream StartMemoryStream = new MemoryStream(),
                                NewMemoryStream = new MemoryStream())
            {

                StartMemoryStream.Write(PassedImage, 0, PassedImage.Length);


                Bitmap startBitmap = new Bitmap(StartMemoryStream);


                Bitmap newBitmap = new Bitmap(width, height);


                newBitmap = ResizeImage(startBitmap, width, height);


                newBitmap.Save(NewMemoryStream, ImageFormat.Jpeg);


                ReturnedThumbnail = NewMemoryStream.ToArray();
            }

            return ReturnedThumbnail;
        }
        // Resize a Bitmap  
        private static Bitmap ResizeImage(Bitmap image, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics gfx = Graphics.FromImage(resizedImage))
            {
                gfx.DrawImage(image, new Rectangle(0, 0, width, height),
                    new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
            }
            return resizedImage;
        }

        public static byte[] GenerateDynamicImage(int R, int G, int B, int width, int height)
        {
            Color customColor = Color.FromArgb(R, G, B);
            SolidBrush shadowBrush = new SolidBrush(customColor);

            byte[] ReturnedThumbnail;
            using (MemoryStream StartMemoryStream = new MemoryStream(),
                                NewMemoryStream = new MemoryStream())
            {
                Bitmap bmp = new Bitmap(width, height);
                using (Graphics graph = Graphics.FromImage(bmp))
                {
                    Rectangle ImageSize = new Rectangle(0, 0, width, height);
                    // graph.FillRectangle(Brushes.White, ImageSize);
                    graph.FillRectangle(shadowBrush, ImageSize);
                }

                bmp.Save(NewMemoryStream, ImageFormat.Jpeg);
                ReturnedThumbnail = NewMemoryStream.ToArray();
            }
            return ReturnedThumbnail;
        }


        /// <summary>
        /// Convert Generic List to Datatable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable GenericListToDataTable<T>(this List<T> list)
        {
            DataTable dt = new DataTable();
            if (list.Count > 0)
            {
                Type listType = list.ElementAt(0).GetType();
                //Get element properties and add datatable columns  
                PropertyInfo[] properties = listType.GetProperties();
                foreach (PropertyInfo property in properties)
                    dt.Columns.Add(new DataColumn() { ColumnName = property.Name });
                foreach (object item in list)
                {
                    DataRow dr = dt.NewRow();
                    foreach (DataColumn col in dt.Columns)
                        dr[col] = listType.GetProperty(col.ColumnName).GetValue(item, null);
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        /// <summary>
        /// Method 2
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable ListToDataTable<T>(List<T> list)
        {
            DataTable dt = new DataTable();

            foreach (PropertyInfo info in typeof(T).GetProperties())
            {
                dt.Columns.Add(new DataColumn(info.Name, info.PropertyType));
            }
            foreach (T t in list)
            {
                DataRow row = dt.NewRow();
                foreach (PropertyInfo info in typeof(T).GetProperties())
                {
                    row[info.Name] = info.GetValue(t, null);
                }
                dt.Rows.Add(row);
            }
            return dt;
        }
        /// <summary>
        /// Converts a Generic List into a DataTable.
        /// </summary>
        /// <param name="genericList">Generic list</param>
        /// <returns>DataTable object</returns>
        public static DataTable GenericListToDataTable1<T>(List<T> genericList)
        {
            DataTable dataTable = null;
            Type listType = genericList.GetType();

            if (listType.IsGenericType & (genericList != null))
            {
                //determine the underlying type the List<> contains
                Type elementType = listType.GetGenericArguments()[0];

                //create empty table -- give it a name in case
                //it needs to be serialized
                dataTable = new DataTable(elementType.Name + "List");

                //define the table -- add a column for each public
                //property or field
                MemberInfo[] memberInfos = elementType.GetMembers(BindingFlags.Public | BindingFlags.Instance);
                foreach (MemberInfo memberInfo in memberInfos)
                {
                    if (memberInfo.MemberType == MemberTypes.Property)
                    {
                        PropertyInfo propertyInfo = memberInfo as PropertyInfo;
                        if (IsNullableType(propertyInfo.PropertyType))
                        {
                            dataTable.Columns.Add(propertyInfo.Name, new NullableConverter(propertyInfo.PropertyType).UnderlyingType);
                        }
                        else
                        {
                            dataTable.Columns.Add(propertyInfo.Name, propertyInfo.PropertyType);
                        }
                    }
                    else if (memberInfo.MemberType == MemberTypes.Field)
                    {
                        FieldInfo fieldInfo = memberInfo as FieldInfo;
                        dataTable.Columns.Add(fieldInfo.Name, fieldInfo.FieldType);
                    }
                }

                //populate the table
                IList listData = genericList as IList;
                foreach (object record in listData)
                {

                    int index = 0;
                    object[] fieldValues = new object[dataTable.Columns.Count];
                    foreach (DataColumn columnData in dataTable.Columns)
                    {
                        MemberInfo memberInfo = elementType.GetMember(columnData.ColumnName)[0];
                        if (memberInfo.MemberType == MemberTypes.Property)
                        {
                            PropertyInfo propertyInfo = memberInfo as PropertyInfo;
                            fieldValues[index] = propertyInfo.GetValue(record, null);
                        }
                        else if (memberInfo.MemberType == MemberTypes.Field)
                        {
                            FieldInfo fieldInfo = memberInfo as FieldInfo;
                            fieldValues[index] = fieldInfo.GetValue(record);
                        }
                        index += 1;
                    }
                    dataTable.Rows.Add(fieldValues);
                }
            }
            return dataTable;
        }

        /// <summary>
        /// Check if a type is Nullable type
        /// </summary>
        /// <param name="propertyType">Type to be checked</param>
        /// <returns>true/false</returns>
        /// <remarks></remarks>
        private static bool IsNullableType(Type propertyType)
        {
            return (propertyType.IsGenericType) && (ReferenceEquals(propertyType.GetGenericTypeDefinition(), typeof(Nullable<>)));
        }
        /// <summary>
        /// Convert Generic List to Dataset
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataSet CreateDataSet<T>(List<T> list)
        {
            //list is nothing or has nothing, return nothing (or add exception handling)
            if (list == null || list.Count == 0) { return null; }

            //get the type of the first obj in the list
            var obj = list[0].GetType();

            //now grab all properties
            var properties = obj.GetProperties();

            //make sure the obj has properties, return nothing (or add exception handling)
            if (properties.Length == 0) { return null; }

            //it does so create the dataset and table
            var dataSet = new DataSet();
            var dataTable = new DataTable();

            //now build the columns from the properties
            var columns = new DataColumn[properties.Length];
            for (int i = 0; i < properties.Length; i++)
            {
                columns[i] = new DataColumn(properties[i].Name, properties[i].PropertyType);
            }

            //add columns to table
            dataTable.Columns.AddRange(columns);

            //now add the list values to the table
            foreach (var item in list)
            {
                //create a new row from table
                var dataRow = dataTable.NewRow();

                //now we have to iterate thru each property of the item and retrieve it's value for the corresponding row's cell
                var itemProperties = item.GetType().GetProperties();

                for (int i = 0; i < itemProperties.Length; i++)
                {
                    dataRow[i] = itemProperties[i].GetValue(item, null);
                }

                //now add the populated row to the table
                dataTable.Rows.Add(dataRow);
            }

            //add table to dataset
            dataSet.Tables.Add(dataTable);

            //return dataset
            return dataSet;
        }
        /// <summary>
        /// Check Date 
        /// </summary>
        /// <param name="date"></param>
        public static bool IsDateTimeValid(string date)
        {
            try
            {
                DateTime realdate = DateTime.Parse(date, CultureInfo.GetCultureInfo("en-gb"));
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Convert Date from dd/MM/yyyy to MM/dd/yyyy
        /// </summary>
        /// <param name="date"></param>
        public static DateTime ConvertDateTime(string date)
        {
            try
            {
                DateTime realdate = DateTime.Parse(date, CultureInfo.GetCultureInfo("en-gb"));
                return realdate;
            }
            catch 
            {
                throw ;
            }
        }

        /// <summary>
        /// Convert image to byte
        /// </summary>
        /// <param name="imgs"></param>
        /// <returns></returns>
        public static byte[] ConvertImagetoByte(string imgs)
        {
            FileStream fs = new FileStream(imgs, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            byte[] image = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();
            return image;
        }

        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            object[] attribs = field.GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (attribs.Length > 0)
            {
                return ((DescriptionAttribute)attribs[0]).Description;
            }
            return String.Empty;
        }
        public static bool IsInteger(string val)
        {
            try
            {
                long x = Convert.ToInt64(val);
                return true;
            }
            catch{
                return false;
            }

        }
        public static bool IsDouble(string val)
        {
            try
            {
                Convert.ToDouble(val);
                return true;
            }
            catch 
            {
                return false;
            }
        }
        public static bool IsDecimal(string val)
        {
            try
            {
                Convert.ToDecimal(val);
                return true;
            }
            catch 
            {
                return false;
            }
        }
        public static bool IsNullOrEmpty(string val)
        {
            try
            {
                return String.IsNullOrEmpty(val);
            }
            catch 
            {
                throw ;
            }
        }
        public static bool IsValidMobileNo(string mobileNo)
        {
            if (mobileNo.Length != 11)
            {
                return false;
            }
            if (!IsInteger(mobileNo))
            {
                return false;
            }

            if (mobileNo.StartsWith("011") ||
                mobileNo.StartsWith("015") ||
                mobileNo.StartsWith("016") ||
                mobileNo.StartsWith("017") ||
                mobileNo.StartsWith("018") ||
                mobileNo.StartsWith("019"))
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public static bool IsElevanValidMobileNo(string mobileNo)
        {
            if (mobileNo.Length != 11)
            {
                return false;
            }
            return true;
        }


        public static void DisplayAlertMessage(char type, string msg)
        {
            if (type == 'S')
            {
                MessageBox.Show(msg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (type == 'W')
            {
                MessageBox.Show(msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (type == 'E')
            {
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
