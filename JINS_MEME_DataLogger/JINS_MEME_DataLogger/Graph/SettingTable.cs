using System;
using System.Data;
using System.IO;
using System.Drawing;
using System.Threading;

namespace JINS_MEME_DataLogger
{
    /// <summary>
    /// �ݒ�l�̓Ǐo���A�ۑ��̏������L�ڂ��܂��B
    /// </summary>
    /// <para>�ݒ�e�[�u���B</para>
    /// <para>�ݒ薼.XML�t�@�C������̓ǂݏo���A�ۑ����s���܂��B</para>
    /// <para>�ݒ荀�ڂ̓J�e�S���[�{KEY�̑g�ݍ��킹�ŊǗ����܂��B</para>
    /// <para>�ݒ�t�@�C���͎��s�p�X\Config�ɂ��邱�Ƃ�O��Ƃ��܂��B</para>
    public class SettingTable : DataTable
    {
        /// <summary>�ݒ薼�B</summary>
        private String settingName;
        /// <summary>�t�@�C���A�N�Z�X�r���pMUTEX�B</summary>
        private static Mutex mutex = new Mutex(false, "SettingTable");

        /// <summary>
        /// �R���X�g���N�^�B
        /// �l�w�肵�ăC���X�^���X���쐬���܂��B
        /// </summary>
        /// <param name="settingName">�ݒ薼�B</param>
        public SettingTable(String settingName)
        {
            DataColumn[] keys = new DataColumn[2];
            DataColumn column;

            this.settingName = settingName;
            base.TableName = this.settingName;

            // category��
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Category";
            base.Columns.Add(column);

            // primary�L�[�ɒǉ�
            keys[0] = column;

            // Key��
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Key";
            base.Columns.Add(column);

            // primary�L�[�ɒǉ�
            keys[1] = column;

            // Value��
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Value";
            base.Columns.Add(column);

            // Set the PrimaryKeys property to the array.
            base.PrimaryKey = keys;

            //�t�@�C���ǂݍ���
            this.ReadConfig();

        }
        /// <summary>
        /// ���ڎ擾�C���f�N�T�B
        /// </summary>
        /// <param name="category">�L�[(�J�e�S���[)�B</param>
        /// <param name="key">�L�[(KEY)�B</param>
        /// <returns>�ݒ�l������</returns>
        public String this[String category, String key]
        {
            get
            {

                return GetStringValue(category, key, "");
            }
            set
            {
                SetStringValue(category, key, value);
            }
        }
        /// <summary>
        /// Integer�ō��ڎ擾�B
        /// </summary>
        /// <param name="category">�L�[(�J�e�S���[)�B</param>
        /// <param name="key">�L�[(KEY)�B</param>
        /// <param name="defaultValue">���ږ��ݒ�̏ꍇ�̃f�t�H���g�l�B</param>
        /// <returns>�ݒ�l</returns>
        public int GetInteger(String category, String key, int defaultValue)
        {
            String str = GetStringValue(category, key, defaultValue.ToString());
            int value = defaultValue;
            int result;
            if (int.TryParse(str, out result) == true)
            {
                value = result;
            }
            return value;
        }
        /// <summary>
        /// Integer�ō��ڐݒ�B
        /// </summary>
        /// <param name="category">�L�[(�J�e�S���[)�B</param>
        /// <param name="key">�L�[(KEY)�B</param>
        /// <param name="value">�ݒ�l�B</param>
        public void SetInteger(String category, String key, int value)
        {
            SetStringValue(category, key, value.ToString());
        }
        /// <summary>
        /// Double�ō��ڎ擾�B
        /// </summary>
        /// <param name="category">�L�[(�J�e�S���[)�B</param>
        /// <param name="key">�L�[(KEY)�B</param>
        /// <param name="defaultValue">���ږ��ݒ�̏ꍇ�̃f�t�H���g�l�B</param>
        /// <returns>�ݒ�l</returns>
        public Double GetDouble(String category, String key, Double defaultValue)
        {
            String str = GetStringValue(category, key, defaultValue.ToString());
            Double value = defaultValue;
            Double result;
            if (Double.TryParse(str, out result) == true)
            {
                value = result;
            }
            return value;
        }
        /// <summary>
        /// Double�ō��ڐݒ�B
        /// </summary>
        /// <param name="category">�L�[(�J�e�S���[)�B</param>
        /// <param name="key">�L�[(KEY)�B</param>
        /// <param name="value">�ݒ�l�B</param>
        public void SetDouble(String category, String key, Double value)
        {
            SetStringValue(category, key, value.ToString());
        }
        /// <summary>
        /// Color�ō��ڎ擾�B
        /// </summary>
        /// <param name="category">�L�[(�J�e�S���[)�B</param>
        /// <param name="key">�L�[(KEY)�B</param>
        /// <param name="defaultValue">���ږ��ݒ�̏ꍇ�̃f�t�H���g�l�B</param>
        /// <returns>�ݒ�l</returns>
        public Color GetColor(String category, String key, Color defaultValue)
        {
            return StringToColor(GetStringValue(category, key, defaultValue.Name));
        }
        /// <summary>
        /// Color�ō��ڐݒ�B
        /// </summary>
        /// <param name="category">�L�[(�J�e�S���[)�B</param>
        /// <param name="key">�L�[(KEY)�B</param>
        /// <param name="value">�ݒ�l�B</param>
        public void SetColor(String category, String key, Color value)
        {
            SetStringValue(category, key, value.Name);
        }
        /// <summary>
        /// bool�ō��ڎ擾�B
        /// </summary>
        /// <param name="category">�L�[(�J�e�S���[)�B</param>
        /// <param name="key">�L�[(KEY)�B</param>
        /// <param name="defaultValue">���ږ��ݒ�̏ꍇ�̃f�t�H���g�l�B</param>
        /// <returns>�ݒ�l</returns>
        public bool GetBool(String category, String key, bool defaultValue)
        {
            String str = GetStringValue(category, key, defaultValue.ToString());
            bool value = true;

            if (!bool.TryParse(str, out value))
            {
                value = true;
                int result;
                if (int.TryParse(str, out result) == true && result == 0)
                {
                    value = false;
                }
            }


            return value;
        }
        /// <summary>
        /// bool�ō��ڐݒ�B
        /// </summary>
        /// <param name="category">�L�[(�J�e�S���[)�B</param>
        /// <param name="key">�L�[(KEY)�B</param>
        /// <param name="value">�ݒ�l�B</param>
        public void SetBool(String category, String key, bool value)
        {
            int intValue = 0;
            if (value)
            {
                intValue = 1;
            }
            SetStringValue(category, key, intValue.ToString());
        }
        /// <summary>
        /// DateTime�ō��ڎ擾�B
        /// </summary>
        /// <param name="category">�L�[(�J�e�S���[)�B</param>
        /// <param name="key">�L�[(KEY)�B</param>
        /// <param name="defaultValue">���ږ��ݒ�̏ꍇ�̃f�t�H���g�l�B</param>
        /// <returns>�ݒ�l</returns>
        public DateTime GetDateTime(String category, String key, DateTime defaultValue)
        {
            String str = GetStringValue(category, key, defaultValue.ToString("F"));
            DateTime value = defaultValue;
            DateTime result ;
            if (DateTime.TryParse(str, out result) == true)
            {
                value = result;
            }
            return result;
        }
        /// <summary>
        /// DateTime�ō��ڐݒ�B
        /// </summary>
        /// <param name="category">�L�[(�J�e�S���[)�B</param>
        /// <param name="key">�L�[(KEY)�B</param>
        /// <param name="value">�ݒ�l�B</param>
        public void SetDateTime(String category, String key, DateTime value)
        {
            SetStringValue(category, key, value.ToString("F"));
        }

        /// <summary>
        /// String�ō��ڎ擾�B
        /// </summary>
        /// <param name="category">�L�[(�J�e�S���[)�B</param>
        /// <param name="key">�L�[(KEY)�B</param>
        /// <param name="defaultValue">���ږ��ݒ�̏ꍇ�̃f�t�H���g�l�B</param>
        /// <returns>�ݒ�l</returns>
        public String GetStringValue(String category, String key, String defaultValue)
        {
            String ret = defaultValue;
            DataRow row = base.Rows.Find(new object[] { category, key });
            if (row != null)
            {
                ret = (String)row["Value"];
            }
            return ret;
        }
        /// <summary>
        /// String�ō��ڐݒ�B
        /// </summary>
        /// <param name="category">�L�[(�J�e�S���[)�B</param>
        /// <param name="key">�L�[(KEY)�B</param>
        /// <param name="value">�ݒ�l�B</param>
        public void SetStringValue(String category, String key, String value)
        {
            try
            {
                //�r������
                mutex.WaitOne();

                DataRow row = base.Rows.Find(new object[] { category, key });
                if (row != null)
                {
                    row["Value"] = value;
                }
                else
                {
                    Add(category, key, value);
                }
            }
            catch
            {
            }
            finally
            {
                // Mutex���b�N���
                mutex.ReleaseMutex();

                //��������
                this.WriteConfig();
            }
        }
        /// <summary>
        /// Point�ŃE�B���h�E��Location�擾�B
        /// </summary>
        /// <param name="category">�L�[(�J�e�S���[)�B</param>
        /// <param name="defaultLocation"></param>
        /// <returns>�ݒ�l</returns>
        public Point GetWindowLocation(String category,Point defaultLocation)
        {
            int top = GetInteger(category, "Top", defaultLocation.X);
            int left = GetInteger(category, "Left", defaultLocation.Y);
            Point location = new Point(left, top);

            return location;
        }
        /// <summary>
        /// Size�ŃE�B���h�E��Size�擾�B
        /// </summary>
        /// <param name="category">�L�[(�J�e�S���[)�B</param>
        /// <param name="defaultSize"></param>
        /// <returns>�ݒ�l</returns>
        public Size GetWindowSize(String category, Size defaultSize)
        {
            int width = GetInteger(category, "Width", defaultSize.Width);
            int height = GetInteger(category, "Height", defaultSize.Height);
            Size size = new Size(width, height);

            return size;
        }


        /// <summary>
        /// Point�ŃE�B���h�E��Location�ݒ�B
        /// </summary>
        /// <param name="category">�L�[(�J�e�S���[)�B</param>
        /// <param name="location">Location�B</param>
        public void SetWindowLocation(String category, Point location)
        {
            SetInteger(category, "Top", location.Y);
            SetInteger(category, "Left", location.X);
        }

        /// <summary>
        /// Size�ŃE�B���h�E��Size�ݒ�B
        /// </summary>
        /// <param name="category">�L�[(�J�e�S���[)�B</param>
        /// <param name="size">Size�B</param>
        public void SetWindowSize(String category, Size size)
        {
            SetInteger(category, "Width", size.Width);
            SetInteger(category, "Height", size.Height);
        }


        /// <summary>
        /// �e�[�u����ADD����B
        /// </summary>
        /// <param name="category">�L�[(�J�e�S���[)�B</param>
        /// <param name="key">�L�[(KEY)�B</param>
        /// <param name="value">�ݒ�l�B</param>
        private void Add(String category, String key, Object value)
        {
            base.Rows.Add(new object[] { category, key, value });
        }

        /// <summary>
        /// �t�@�C������ǂށB
        /// </summary>
        public void ReadConfig()
        {
            try
            {
                //�r������
                mutex.WaitOne();

                //��U�폜
                base.Clear();

                String path = GetPath();
                base.ReadXml(path);
            }
            catch 
            {
            }
            finally
            {
                // Mutex���b�N���
                mutex.ReleaseMutex();
            }

        }

        /// <summary>
        /// �t�@�C���ɏ����B
        /// </summary>
        public void WriteConfig()
        {
            try
            {
                //�r������
                mutex.WaitOne();

                String path = GetPath();
                String directory = Directory.GetParent(path).FullName;
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                base.WriteXml(path);
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                // Mutex���b�N���
                mutex.ReleaseMutex();
            }
�@       }



        /// <summary>
        /// �p�X���� "���s�p�X\Config"�Œ�B
        /// </summary>
        private String GetPath()
        {
            //string appPath = Path.Combine(System.Windows.Forms.Application.LocalUserAppDataPath, "Config");
            //String commonPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
            //                                Application.CompanyName, Application.ProductName,"Config");

            string configPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                                                    System.Windows.Forms.Application.CompanyName,
                                                    //System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion,
                                                    "MEME academic",
                                                    "Config");

            String path = Path.Combine(configPath, settingName + ".Config"); 

            return path;
        }

        /// <summary>
        /// <para>�����񂩂�Color�ɕϊ�����B</para>
        /// <para>������̓V�X�e����`�̂���(Blue,Yellow��)���A�P�U�i�`����ARGB�l�B</para>
        /// </summary>
        /// <param name="colorString">������B</param>
        /// <returns>�ݒ�l</returns>
        public static Color StringToColor(String colorString)
        {
            Color ret;
            int argb;
            if (Int32.TryParse(colorString, System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.InvariantCulture, out argb))
            {
                ret = Color.FromArgb(argb);
            }
            else
            {
                ret = Color.FromName(colorString);
            }
            return ret;
        }


    }


}
