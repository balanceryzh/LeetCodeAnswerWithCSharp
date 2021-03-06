﻿using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Globalization;
using Microsoft.International.Converters.PinYinConverter;

namespace TypeTool
{
    public static class StringHelper
    {
        #region 属性变量

        /// <summary>
        /// 拼音编码
        /// </summary>
        private static int[] pyValue
        {
            get
            {
                return new int[]{
        -20319,-20317,-20304,-20295,-20292,-20283,-20265,-20257,-20242,-20230,-20051,-20036,
        -20032,-20026,-20002,-19990,-19986,-19982,-19976,-19805,-19784,-19775,-19774,-19763,
        -19756,-19751,-19746,-19741,-19739,-19728,-19725,-19715,-19540,-19531,-19525,-19515,
        -19500,-19484,-19479,-19467,-19289,-19288,-19281,-19275,-19270,-19263,-19261,-19249,
        -19243,-19242,-19238,-19235,-19227,-19224,-19218,-19212,-19038,-19023,-19018,-19006,
        -19003,-18996,-18977,-18961,-18952,-18783,-18774,-18773,-18763,-18756,-18741,-18735,
        -18731,-18722,-18710,-18697,-18696,-18526,-18518,-18501,-18490,-18478,-18463,-18448,
        -18447,-18446,-18239,-18237,-18231,-18220,-18211,-18201,-18184,-18183, -18181,-18012,
        -17997,-17988,-17970,-17964,-17961,-17950,-17947,-17931,-17928,-17922,-17759,-17752,
        -17733,-17730,-17721,-17703,-17701,-17697,-17692,-17683,-17676,-17496,-17487,-17482,
        -17468,-17454,-17433,-17427,-17417,-17202,-17185,-16983,-16970,-16942,-16915,-16733,
        -16708,-16706,-16689,-16664,-16657,-16647,-16474,-16470,-16465,-16459,-16452,-16448,
        -16433,-16429,-16427,-16423,-16419,-16412,-16407,-16403,-16401,-16393,-16220,-16216,
        -16212,-16205,-16202,-16187,-16180,-16171,-16169,-16158,-16155,-15959,-15958,-15944,
        -15933,-15920,-15915,-15903,-15889,-15878,-15707,-15701,-15681,-15667,-15661,-15659,
        -15652,-15640,-15631,-15625,-15454,-15448,-15436,-15435,-15419,-15416,-15408,-15394,
        -15385,-15377,-15375,-15369,-15363,-15362,-15183,-15180,-15165,-15158,-15153,-15150,
        -15149,-15144,-15143,-15141,-15140,-15139,-15128,-15121,-15119,-15117,-15110,-15109,
        -14941,-14937,-14933,-14930,-14929,-14928,-14926,-14922,-14921,-14914,-14908,-14902,
        -14894,-14889,-14882,-14873,-14871,-14857,-14678,-14674,-14670,-14668,-14663,-14654,
        -14645,-14630,-14594,-14429,-14407,-14399,-14384,-14379,-14368,-14355,-14353,-14345,
        -14170,-14159,-14151,-14149,-14145,-14140,-14137,-14135,-14125,-14123,-14122,-14112,
        -14109,-14099,-14097,-14094,-14092,-14090,-14087,-14083,-13917,-13914,-13910,-13907,
        -13906,-13905,-13896,-13894,-13878,-13870,-13859,-13847,-13831,-13658,-13611,-13601,
        -13406,-13404,-13400,-13398,-13395,-13391,-13387,-13383,-13367,-13359,-13356,-13343,
        -13340,-13329,-13326,-13318,-13147,-13138,-13120,-13107,-13096,-13095,-13091,-13076,
        -13068,-13063,-13060,-12888,-12875,-12871,-12860,-12858,-12852,-12849,-12838,-12831,
        -12829,-12812,-12802,-12607,-12597,-12594,-12585,-12556,-12359,-12346,-12320,-12300,
        -12120,-12099,-12089,-12074,-12067,-12058,-12039,-11867,-11861,-11847,-11831,-11798,
        -11781,-11604,-11589,-11536,-11358,-11340,-11339,-11324,-11303,-11097,-11077,-11067,
        -11055,-11052,-11045,-11041,-11038,-11024,-11020,-11019,-11018,-11014,-10838,-10832,
        -10815,-10800,-10790,-10780,-10764,-10587,-10544,-10533,-10519,-10331,-10329,-10328,
        -10322,-10315,-10309,-10307,-10296,-10281,-10274,-10270,-10262,-10260,-10256,-10254
        };
            }
        }

        /// <summary>
        /// 拼音编码
        /// </summary>
        private static string[] pyName
        {
            get
            {
                return new string[]{
        "A","Ai","An","Ang","Ao","Ba","Bai","Ban","Bang","Bao","Bei","Ben",
        "Beng","Bi","Bian","Biao","Bie","Bin","Bing","Bo","Bu","Ba","Cai","Can",
        "Cang","Cao","Ce","Ceng","Cha","Chai","Chan","Chang","Chao","Che","Chen","Cheng",
        "Chi","Chong","Chou","Chu","Chuai","Chuan","Chuang","Chui","Chun","Chuo","Ci","Cong",
        "Cou","Cu","Cuan","Cui","Cun","Cuo","Da","Dai","Dan","Dang","Dao","De",
        "Deng","Di","Dian","Diao","Die","Ding","Diu","Dong","Dou","Du","Duan","Dui",
        "Dun","Duo","E","En","Er","Fa","Fan","Fang","Fei","Fen","Feng","Fo",
        "Fou","Fu","Ga","Gai","Gan","Gang","Gao","Ge","Gei","Gen","Geng","Gong",
        "Gou","Gu","Gua","Guai","Guan","Guang","Gui","Gun","Guo","Ha","Hai","Han",
        "Hang","Hao","He","Hei","Hen","Heng","Hong","Hou","Hu","Hua","Huai","Huan",
        "Huang","Hui","Hun","Huo","Ji","Jia","Jian","Jiang","Jiao","Jie","Jin","Jing",
        "Jiong","Jiu","Ju","Juan","Jue","Jun","Ka","Kai","Kan","Kang","Kao","Ke",
        "Ken","Keng","Kong","Kou","Ku","Kua","Kuai","Kuan","Kuang","Kui","Kun","Kuo",
        "La","Lai","Lan","Lang","Lao","Le","Lei","Leng","Li","Lia","Lian","Liang",
        "Liao","Lie","Lin","Ling","Liu","Long","Lou","Lu","Lv","Luan","Lue","Lun",
        "Luo","Ma","Mai","Man","Mang","Mao","Me","Mei","Men","Meng","Mi","Mian",
        "Miao","Mie","Min","Ming","Miu","Mo","Mou","Mu","Na","Nai","Nan","Nang",
        "Nao","Ne","Nei","Nen","Neng","Ni","Nian","Niang","Niao","Nie","Nin","Ning",
        "Niu","Nong","Nu","Nv","Nuan","Nue","Nuo","O","Ou","Pa","Pai","Pan",
        "Pang","Pao","Pei","Pen","Peng","Pi","Pian","Piao","Pie","Pin","Ping","Po",
        "Pu","Qi","Qia","Qian","Qiang","Qiao","Qie","Qin","Qing","Qiong","Qiu","Qu",
        "Quan","Que","Qun","Ran","Rang","Rao","Re","Ren","Reng","Ri","Rong","Rou",
        "Ru","Ruan","Rui","Run","Ruo","Sa","Sai","San","Sang","Sao","Se","Sen",
        "Seng","Sha","Shai","Shan","Shang","Shao","She","Shen","Sheng","Shi","Shou","Shu",
        "Shua","Shuai","Shuan","Shuang","Shui","Shun","Shuo","Si","Song","Sou","Su","Suan",
        "Sui","Sun","Suo","Ta","Tai","Tan","Tang","Tao","Te","Teng","Ti","Tian",
        "Tiao","Tie","Ting","Tong","Tou","Tu","Tuan","Tui","Tun","Tuo","Wa","Wai",
        "Wan","Wang","Wei","Wen","Weng","Wo","Wu","Xi","Xia","Xian","Xiang","Xiao",
        "Xie","Xin","Xing","Xiong","Xiu","Xu","Xuan","Xue","Xun","Ya","Yan","Yang",
        "Yao","Ye","Yi","Yin","Ying","Yo","Yong","You","Yu","Yuan","Yue","Yun",
        "Za", "Zai","Zan","Zang","Zao","Ze","Zei","Zen","Zeng","Zha","Zhai","Zhan",
        "Zhang","Zhao","Zhe","Zhen","Zheng","Zhi","Zhong","Zhou","Zhu","Zhua","Zhuai","Zhuan",
        "Zhuang","Zhui","Zhun","Zhuo","Zi","Zong","Zou","Zu","Zuan","Zui","Zun","Zuo"
};
            }
        }

        /// <summary>
        /// 标点符号
        /// </summary>
        public static string[] Punctuations = new string[] {
"。","，","、","＇","：","∶","；","?","‘","’","","“","”","〝","〞","ˆ","ˇ","﹕","︰","﹔","﹖","﹑","·","¨","…",".","¸",";","！","´","？","！","～","—","ˉ","","｜","‖","＂","〃","｀","@","﹫","¡","¿","﹏","﹋","﹌","︴","々","﹟","#","﹩","$","﹠","&","﹪","%","*","﹡","﹢","﹦","﹤","‐","￣","¯","―","﹨","ˆ","˜","﹍","﹎","+","=","<","­","­","＿","_","-","\\","ˇ","~","﹉","﹊","（","）","","〈","〉","‹","›","﹛","﹜","『","』","〖","〗","［","］","《","》","〔","〕","{","}","「","」","【","】","︵","︷","︿","︹","︽","_","","﹁","﹃","︻","︶","︸","﹀","︺","︾","ˉ","﹂","﹄","︼"};


        #endregion

        #region 获取内容
        /// <summary>
        /// 获取中文数量
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int GetHanNumFromString(string str)
        {
            int count = 0;
            Regex regex = new Regex(@"^[\u4E00-\u9FA5]{0,}$");

            for (int i = 0; i < str.Length; i++)
            {
                if (regex.IsMatch(str[i].ToString()))
                {
                    count++;
                }
            }

            return count;
        }
        /// <summary>
        /// 获取对象字符串
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>字符串</returns>
        public static string Get(object obj, string defaultValue = "")
        {
            if (obj == null)
                return defaultValue;

            try
            {
                return obj.ToString();
            }
            catch
            {
                return defaultValue;
            }

        }

        /// <summary>
        /// 获取字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Get(string str, string defaultValue = "")
        {
            if (str == null)
                return defaultValue;
            return str;
        }

        /// <summary>
        /// 获取整数字符串
        /// </summary>
        /// <param name="value">整数值</param>
        /// <param name="format">格式</param>
        /// <param name="defaultValue"></param>
        /// <returns>字符串</returns>
        public static string Get(int value, int defaultValue = 0, string format = null)
        {
            return value.ToString(format);
        }

        /// <summary>
        /// 获取小数字符串
        /// </summary>
        /// <param name="value">小数值</param>
        /// <param name="format">格式</param>
        /// <param name="defaultValue"></param>
        /// <returns>字符串</returns>
        public static string Get(decimal value, string format = null, decimal defaultValue = 0)
        {
            return value.ToString(format);
        }

        /// <summary>
        /// 获取双精度数字符串
        /// </summary>
        /// <param name="value">双精度数</param>
        /// <param name="format">格式</param>
        /// <param name="defaultValue"></param>
        /// <returns>字符串</returns>
        public static string Get(double value, string format = null, double defaultValue = 0)
        {
            return value.ToString(format);
        }

        /// <summary>
        /// 获取单精度数小数字符串
        /// </summary>
        /// <param name="value">单精度数</param>
        /// <param name="format">格式</param>
        /// <param name="defaultValue"></param>
        /// <returns>字符串</returns>
        public static string Get(float value, string format = null, float defaultValue = 0)
        {
            return value.ToString(format);
        }

        /// <summary>
        /// 获取长整数字符串
        /// </summary>
        /// <param name="value">单精度数</param>
        /// <param name="format">格式</param>
        /// <param name="defaultValue"></param>
        /// <returns>字符串</returns>
        public static string Get(long value, string format = null, long defaultValue = 0)
        {
            return value.ToString(format);
        }

        /// <summary>
        /// 获取日期字符串
        /// </summary>
        /// <param name="dateTime">时间</param>
        /// <param name="format">格式</param>
        /// <param name="defaultDateTime">默认值</param>
        /// <returns>返回日期字符串</returns>
        public static string Get(DateTime dateTime, string format = "yyyy-MM-dd HH:mm:ss", DateTime? defaultDateTime = null)
        {
            return dateTime.ToString(format);
        }

        /// <summary>
        /// 获取GUID字符串
        /// 默认 "D" 10244798-9a34-4245-b1ef-9143f9b1e68a 
        /// "N" 102447989a344245b1ef9143f9b1e68a
        /// "B" {10244798-9a34-4245-b1ef-9143f9b1e68a}
        /// "P" (10244798-9a34-4245-b1ef-9143f9b1e68a)
        /// </summary>
        /// <param name="value"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string Get(Guid value, string format = "D", bool isCaseUpper = false)
        {
            string str = value.ToString(format);
            return isCaseUpper ? str.ToUpper() : str;
        }

        /// <summary>
        /// 获取字节数组字符串
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <param name="encoding">编码</param>
        /// <returns></returns>
        public static string Get(byte[] bytes, Encoding encoding = null)
        {
            if (encoding == null)
                encoding = System.Text.Encoding.UTF8;

            if (bytes == null)
                return "";
            if (bytes.Length == 0)
                return "";
            return encoding.GetString(bytes);
        }

        /// <summary>
        /// 获取字节流字符串
        /// </summary>
        /// <param name="stream">字节流</param>
        /// <returns>字符串</returns>
        public static string Get(Stream stream)
        {
            if (stream != null)
            {
                stream.Seek(0, SeekOrigin.Begin);
                return new StreamReader(stream).ReadToEnd();
            }
            return "";
        }

        /// <summary>
        /// 获取集合字符串(返回a=b c=d格式)
        /// </summary>
        /// <param name="list">NameValueCollection 数据</param>
        /// <param name="separator">分割符</param>
        /// <returns>字符串</returns>
        public static string Get(NameValueCollection list, char separator = '&')
        {
            if (list == null || (list != null && list.Count == 0))
                return "";
            StringBuilder build = new StringBuilder();
            foreach (string key in list.Keys)
            {
                build.AppendFormat("{0}={1}{2}", key, list[key], separator);
            }
            return build.Length == 0 ? "" : build.ToString().Trim(separator);
        }

        /// <summary>
        /// 获取集合字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string Get<T>(IEnumerable<T> list, string separator = ",")
        {
            return string.Join(separator, list);
        }

        #endregion

        #region 扩展方法

        /// <summary>
        /// 为指定格式的字符串填充相应对象来生成字符串
        /// </summary>
        /// <param name="format">字符串格式，占位符以{n}表示</param>
        /// <param name="args">用于填充占位符的参数</param>
        /// <returns>格式化后的字符串</returns>
        [DebuggerStepThrough]
        public static string FormatCulture(this string format, params object[] args)
        {
            if (format == null)
                throw new NullReferenceException("Format is null");
            return string.Format(CultureInfo.CurrentCulture, format, args);
        }

        /// <summary>
        /// 获取默认字符串(转小写，移除前后空)
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="isLower">是否小写(默认true)</param>
        /// <param name="trimStr">需前后移除字符串 默认空格</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static string FormatDefault(this string obj, bool isLower = true, string trimStr = " ", string defaultValue = "")
        {
            var str = Get(obj, defaultValue);
            if (!string.IsNullOrEmpty(trimStr) && trimStr.Length > 0)
            {
                foreach (var item in trimStr.ToCharArray())
                {
                    str = str.Trim(item);
                }
            }
            if (isLower)
            {
                str = str.ToLower();
            }
            return str;
        }

        /// <summary>
        /// 移除前字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="trimStr"></param>
        /// <returns></returns>
        public static string FormatTrimStart(this string str, string trimStr = " ")
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;

            if (!string.IsNullOrEmpty(trimStr) && trimStr.Length > 0)
            {
                foreach (var item in trimStr.ToCharArray())
                {
                    str = str.TrimStart(item);
                }
            }
            return str;
        }

        /// <summary>
        /// 移除后字符串
        /// </summary>
        public static string FormatTrimEnd(this string str, string trimStr = " ")
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;

            if (!string.IsNullOrEmpty(trimStr) && trimStr.Length > 0)
            {
                foreach (var item in trimStr.ToCharArray())
                {
                    str = str.TrimEnd(item);
                }
            }
            return str;
        }

        /// <summary>
        /// 转为汉语拼音缩写
        /// </summary>
        /// <param name="text">需转换的文本</param>
        /// <returns></returns>
        public static string FormatSpell(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "";

            int i = 0;
            ushort key = 0;
            string strResult = string.Empty;            //创建两个不同的encoding对象     
            Encoding unicode = Encoding.Unicode;
            //创建GBK码对象     
            Encoding gbk = Encoding.GetEncoding(936);
            //将unicode字符串转换为字节     
            byte[] unicodeBytes = unicode.GetBytes(text);
            //再转化为GBK码     
            byte[] gbkBytes = Encoding.Convert(unicode, gbk, unicodeBytes);
            while (i < gbkBytes.Length)
            {
                //如果为数字\字母\其他ASCII符号     
                if (gbkBytes[i] <= 127)
                {
                    strResult = strResult + (char)gbkBytes[i];
                    i++;
                }
                else
                {
                    key = (ushort)(gbkBytes[i] * 256 + gbkBytes[i + 1]);

                    if (key >= '\uB0A1' && key <= '\uB0C4')
                    {
                        strResult = strResult + "A";
                    }
                    else if (key >= '\uB0C5' && key <= '\uB2C0')
                    {
                        strResult = strResult + "B";
                    }
                    else if (key >= '\uB2C1' && key <= '\uB4ED')
                    {
                        strResult = strResult + "C";
                    }
                    else if (key >= '\uB4EE' && key <= '\uB6E9')
                    {
                        strResult = strResult + "D";
                    }
                    else if (key >= '\uB6EA' && key <= '\uB7A1')
                    {
                        strResult = strResult + "E";
                    }
                    else if (key >= '\uB7A2' && key <= '\uB8C0')
                    {
                        strResult = strResult + "F";
                    }
                    else if (key >= '\uB8C1' && key <= '\uB9FD')
                    {
                        strResult = strResult + "G";
                    }
                    else if (key >= '\uB9FE' && key <= '\uBBF6')
                    {
                        strResult = strResult + "H";
                    }
                    else if (key >= '\uBBF7' && key <= '\uBFA5')
                    {
                        strResult = strResult + "J";
                    }
                    else if (key >= '\uBFA6' && key <= '\uC0AB')
                    {
                        strResult = strResult + "K";
                    }
                    else if (key >= '\uC0AC' && key <= '\uC2E7')
                    {
                        strResult = strResult + "L";
                    }
                    else if (key >= '\uC2E8' && key <= '\uC4C2')
                    {
                        strResult = strResult + "M";
                    }
                    else if (key >= '\uC4C3' && key <= '\uC5B5')
                    {
                        strResult = strResult + "N";
                    }
                    else if (key >= '\uC5B6' && key <= '\uC5BD')
                    {
                        strResult = strResult + "O";
                    }
                    else if (key >= '\uC5BE' && key <= '\uC6D9')
                    {
                        strResult = strResult + "P";
                    }
                    else if (key >= '\uC6DA' && key <= '\uC8BA')
                    {
                        strResult = strResult + "Q";
                    }
                    else if (key >= '\uC8BB' && key <= '\uC8F5')
                    {
                        strResult = strResult + "R";
                    }
                    else if (key >= '\uC8F6' && key <= '\uCBF9')
                    {
                        strResult = strResult + "S";
                    }
                    else if (key >= '\uCBFA' && key <= '\uCDD9')
                    {
                        strResult = strResult + "T";
                    }
                    else if (key >= '\uCDDA' && key <= '\uCEF3')
                    {
                        strResult = strResult + "W";
                    }
                    else if (key >= '\uCEF4' && key <= '\uD188')
                    {
                        strResult = strResult + "X";
                    }
                    else if (key >= '\uD1B9' && key <= '\uD4D0')
                    {
                        strResult = strResult + "Y";
                    }
                    else if (key >= '\uD4D1' && key <= '\uD7F9')
                    {
                        strResult = strResult + "Z";
                    }
                    else
                    {
                        strResult = strResult + "?";
                    }
                    i = i + 2;
                }
            }
            return strResult;
        }

        /// <summary>  
        /// 把汉字转换成拼音(全拼)  
        /// </summary>  
        /// <param name="text">需转换的文本</param>  
        /// <returns>转换后的拼音(全拼)字符串</returns>  
        public static string FormatLetter(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "";

            // 匹配中文字符  
            Regex regex = new Regex("^[\u4e00-\u9fa5]{1}");
            byte[] array = new byte[2];
            string pyString = "";
            int chrAsc = 0;
            int i1 = 0;
            int i2 = 0;
            char[] noWChar = text.ToCharArray();
            for (int j = 0; j < noWChar.Length; j++)
            {
                // 中文字符  
                if (regex.IsMatch(noWChar[j].ToString()))
                {
                    array = System.Text.Encoding.Default.GetBytes(noWChar[j].ToString());
                    i1 = (short)(array[0]);
                    i2 = (short)(array[1]);
                    chrAsc = i1 * 256 + i2 - 65536;
                    if (chrAsc > 0 && chrAsc < 160)
                    {
                        pyString += noWChar[j];
                    }
                    else
                    {
                        // 修正部分文字  
                        if (chrAsc == -9254)  // 修正“圳”字  
                            pyString += "Zhen";
                        else
                        {
                            for (int i = (pyValue.Length - 1); i >= 0; i--)
                            {
                                if (pyValue[i] <= chrAsc)
                                {
                                    pyString += pyName[i];
                                    break;
                                }
                            }
                        }
                    }
                }
                // 非中文字符  
                else
                {
                    pyString += noWChar[j].ToString();
                }
            }
            return pyString;
        }

        /// <summary>  
        /// 转为汉语拼音缩写(首字母)，不是汉字则原样输出  
        /// </summary>  
        /// <param name="text">需转换的文本</param>  
        /// <returns></returns>  
        public static string FormatLetterPrefix(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "";

            string ls_second_eng = "CJWGNSPGCGNESYPBTYYZDXYKYGTDJNNJQMBSGZSCYJSYYQPGKBZGYCYWJKGKLJSWKPJQHYTWDDZLSGMRYPYWWCCKZNKYDGTTNGJEYKKZYTCJNMCYLQLYPYQFQRPZSLWBTGKJFYXJWZLTBNCXJJJJZXDTTSQZYCDXXHGCKBPHFFSSWYBGMXLPBYLLLHLXSPZMYJHSOJNGHDZQYKLGJHSGQZHXQGKEZZWYSCSCJXYEYXADZPMDSSMZJZQJYZCDJZWQJBDZBXGZNZCPWHKXHQKMWFBPBYDTJZZKQHYLYGXFPTYJYYZPSZLFCHMQSHGMXXSXJJSDCSBBQBEFSJYHWWGZKPYLQBGLDLCCTNMAYDDKSSNGYCSGXLYZAYBNPTSDKDYLHGYMYLCXPYCJNDQJWXQXFYYFJLEJBZRXCCQWQQSBNKYMGPLBMJRQCFLNYMYQMSQTRBCJTHZTQFRXQ" +
          "HXMJJCJLXQGJMSHZKBSWYEMYLTXFSYDSGLYCJQXSJNQBSCTYHBFTDCYZDJWYGHQFRXWCKQKXEBPTLPXJZSRMEBWHJLBJSLYYSMDXLCLQKXLHXJRZJMFQHXHWYWSBHTRXXGLHQHFNMNYKLDYXZPWLGGTMTCFPAJJZYLJTYANJGBJPLQGDZYQYAXBKYSECJSZNSLYZHZXLZCGHPXZHZNYTDSBCJKDLZAYFMYDLEBBGQYZKXGLDNDNYSKJSHDLYXBCGHXYPKDJMMZNGMMCLGWZSZXZJFZNMLZZTHCSYDBDLLSCDDNLKJYKJSYCJLKOHQASDKNHCSGANHDAASHTCPLCPQYBSDMPJLPCJOQLCDHJJYSPRCHNWJNLHLYYQYYWZPTCZGWWMZFFJQQQQYXACLBHKDJXDGMMYDJXZLLSYGXGKJRYWZWYCLZMSSJZLDBYDCFCXYHLXCHYZJQSFQAGMNYXPFRKSSB" +
          "JLYXYSYGLNSCMHCWWMNZJJLXXHCHSYDSTTXRYCYXBYHCSMXJSZNPWGPXXTAYBGAJCXLYSDCCWZOCWKCCSBNHCPDYZNFCYYTYCKXKYBSQKKYTQQXFCWCHCYKELZQBSQYJQCCLMTHSYWHMKTLKJLYCXWHEQQHTQHZPQSQSCFYMMDMGBWHWLGSSLYSDLMLXPTHMJHWLJZYHZJXHTXJLHXRSWLWZJCBXMHZQXSDZPMGFCSGLSXYMJSHXPJXWMYQKSMYPLRTHBXFTPMHYXLCHLHLZYLXGSSSSTCLSLDCLRPBHZHXYYFHBBGDMYCNQQWLQHJJZYWJZYEJJDHPBLQXTQKWHLCHQXAGTLXLJXMSLXHTZKZJECXJCJNMFBYCSFYWYBJZGNYSDZSQYRSLJPCLPWXSDWEJBJCBCNAYTWGMPAPCLYQPCLZXSBNMSGGFNZJJBZSFZYNDXHPLQKZCZWALSBCCJXJYZGWKYP" +
          "SGXFZFCDKHJGXDLQFSGDSLQWZKXTMHSBGZMJZRGLYJBPMLMSXLZJQQHZYJCZYDJWBMJKLDDPMJEGXYHYLXHLQYQHKYCWCJMYYXNATJHYCCXZPCQLBZWWYTWBQCMLPMYRJCCCXFPZNZZLJPLXXYZTZLGDLDCKLYRZZGQTGJHHHJLJAXFGFJZSLCFDQZLCLGJDJCSNCLLJPJQDCCLCJXMYZFTSXGCGSBRZXJQQCTZHGYQTJQQLZXJYLYLBCYAMCSTYLPDJBYREGKLZYZHLYSZQLZNWCZCLLWJQJJJKDGJZOLBBZPPGLGHTGZXYGHZMYCNQSYCYHBHGXKAMTXYXNBSKYZZGJZLQJDFCJXDYGJQJJPMGWGJJJPKQSBGBMMCJSSCLPQPDXCDYYKYFCJDDYYGYWRHJRTGZNYQLDKLJSZZGZQZJGDYKSHPZMTLCPWNJAFYZDJCNMWESCYGLBTZCGMSSLLYXQSXSBSJS" +
          "BBSGGHFJLWPMZJNLYYWDQSHZXTYYWHMCYHYWDBXBTLMSYYYFSXJCSDXXLHJHFSSXZQHFZMZCZTQCXZXRTTDJHNNYZQQMNQDMMGYYDXMJGDHCDYZBFFALLZTDLTFXMXQZDNGWQDBDCZJDXBZGSQQDDJCMBKZFFXMKDMDSYYSZCMLJDSYNSPRSKMKMPCKLGDBQTFZSWTFGGLYPLLJZHGJJGYPZLTCSMCNBTJBQFKTHBYZGKPBBYMTTSSXTBNPDKLEYCJNYCDYKZDDHQHSDZSCTARLLTKZLGECLLKJLQJAQNBDKKGHPJTZQKSECSHALQFMMGJNLYJBBTMLYZXDCJPLDLPCQDHZYCBZSCZBZMSLJFLKRZJSNFRGJHXPDHYJYBZGDLQCSEZGXLBLGYXTWMABCHECMWYJYZLLJJYHLGBDJLSLYGKDZPZXJYYZLWCXSZFGWYYDLYHCLJSCMBJHBLYZLYCBLYDPDQYSXQZB" +
          "YTDKYXJYYCNRJMDJGKLCLJBCTBJDDBBLBLCZQRPXJCGLZCSHLTOLJNMDDDLNGKAQHQHJGYKHEZNMSHRPHQQJCHGMFPRXHJGDYCHGHLYRZQLCYQJNZSQTKQJYMSZSWLCFQQQXYFGGYPTQWLMCRNFKKFSYYLQBMQAMMMYXCTPSHCPTXXZZSM" + "ALBXYFBPNLSFHTGJWEJJXXGLLJSTGSHJQLZFKCGNNDSZFDEQFHBSAQTGLLBXMMYGSZLDYDQMJJRGBJTKGDHGKBLQKBDMBYLXWCXYTTYBKMRTJZXQJBHLMHMJJZMQASLDCYXYQDLQCAFYWYXQHZ";
            string ls_second_ch = "亍丌兀丐廿卅丕亘丞鬲孬噩丨禺丿匕乇夭爻卮氐囟胤馗毓睾鼗丶亟" +
          "鼐乜乩亓芈孛啬嘏仄厍厝厣厥厮靥赝匚叵匦匮匾赜卦卣刂刈刎刭刳刿剀剌剞剡剜蒯剽劂劁劐劓冂罔亻仃仉仂仨仡仫仞伛仳伢佤仵伥伧伉伫佞佧攸佚佝佟佗伲伽佶佴侑侉侃侏佾佻侪佼侬侔俦俨俪俅俚俣俜俑俟俸倩偌俳倬倏倮倭俾倜倌倥倨偾偃偕偈偎偬偻傥傧傩傺僖儆僭僬僦僮儇儋仝氽佘佥俎龠氽籴兮巽黉馘冁夔勹匍訇匐凫夙兕亠兖亳衮袤亵脔裒禀嬴蠃羸冫冱冽冼凇冖冢冥讠讦讧讪讴讵讷诂诃诋诏诎诒诓诔诖诘诙诜诟诠诤诨诩诮诰诳诶诹诼诿谀谂谄谇谌谏谑谒谔谕谖谙谛谘谝谟谠谡谥谧谪谫谮谯谲谳谵谶卩卺阝阢阡阱阪阽阼" +
          "陂陉陔陟陧陬陲陴隈隍隗隰邗邛邝邙邬邡邴邳邶邺邸邰郏郅邾郐郄郇郓郦郢郜郗郛郫郯郾鄄鄢鄞鄣鄱鄯鄹酃酆刍奂劢劬劭劾哿勐勖勰叟燮矍廴凵凼鬯厶弁畚巯坌垩垡塾墼壅壑圩圬圪圳圹圮圯坜圻坂坩垅坫垆坼坻坨坭坶坳垭垤垌垲埏垧垴垓垠埕埘埚埙埒垸埴埯埸埤埝堋堍埽埭堀堞堙塄堠塥塬墁墉墚墀馨鼙懿艹艽艿芏芊芨芄芎芑芗芙芫芸芾芰苈苊苣芘芷芮苋苌苁芩芴芡芪芟苄苎芤苡茉苷苤茏茇苜苴苒苘茌苻苓茑茚茆茔茕苠苕茜荑荛荜茈莒茼茴茱莛荞茯荏荇荃荟荀茗荠茭茺茳荦荥荨茛荩荬荪荭荮莰荸莳莴莠莪莓莜莅荼莶莩荽莸荻" +
          "莘莞莨莺莼菁萁菥菘堇萘萋菝菽菖萜萸萑萆菔菟萏萃菸菹菪菅菀萦菰菡葜葑葚葙葳蒇蒈葺蒉葸萼葆葩葶蒌蒎萱葭蓁蓍蓐蓦蒽蓓蓊蒿蒺蓠蒡蒹蒴蒗蓥蓣蔌甍蔸蓰蔹蔟蔺蕖蔻蓿蓼蕙蕈蕨蕤蕞蕺瞢蕃蕲蕻薤薨薇薏蕹薮薜薅薹薷薰藓藁藜藿蘧蘅蘩蘖蘼廾弈夼奁耷奕奚奘匏尢尥尬尴扌扪抟抻拊拚拗拮挢拶挹捋捃掭揶捱捺掎掴捭掬掊捩掮掼揲揸揠揿揄揞揎摒揆掾摅摁搋搛搠搌搦搡摞撄摭撖摺撷撸撙撺擀擐擗擤擢攉攥攮弋忒甙弑卟叱叽叩叨叻吒吖吆呋呒呓呔呖呃吡呗呙吣吲咂咔呷呱呤咚咛咄呶呦咝哐咭哂咴哒咧咦哓哔呲咣哕咻咿哌哙哚哜咩" +
          "咪咤哝哏哞唛哧唠哽唔哳唢唣唏唑唧唪啧喏喵啉啭啁啕唿啐唼唷啖啵啶啷唳唰啜喋嗒喃喱喹喈喁喟啾嗖喑啻嗟喽喾喔喙嗪嗷嗉嘟嗑嗫嗬嗔嗦嗝嗄嗯嗥嗲嗳嗌嗍嗨嗵嗤辔嘞嘈嘌嘁嘤嘣嗾嘀嘧嘭噘嘹噗嘬噍噢噙噜噌噔嚆噤噱噫噻噼嚅嚓嚯囔囗囝囡囵囫囹囿圄圊圉圜帏帙帔帑帱帻帼帷幄幔幛幞幡岌屺岍岐岖岈岘岙岑岚岜岵岢岽岬岫岱岣峁岷峄峒峤峋峥崂崃崧崦崮崤崞崆崛嵘崾崴崽嵬嵛嵯嵝嵫嵋嵊嵩嵴嶂嶙嶝豳嶷巅彳彷徂徇徉後徕徙徜徨徭徵徼衢彡犭犰犴犷犸狃狁狎狍狒狨狯狩狲狴狷猁狳猃狺狻猗猓猡猊猞猝猕猢猹猥猬猸猱獐獍獗獠獬獯獾" +
          "舛夥飧夤夂饣饧饨饩饪饫饬饴饷饽馀馄馇馊馍馐馑馓馔馕庀庑庋庖庥庠庹庵庾庳赓廒廑廛廨廪膺忄忉忖忏怃忮怄忡忤忾怅怆忪忭忸怙怵怦怛怏怍怩怫怊怿怡恸恹恻恺恂恪恽悖悚悭悝悃悒悌悛惬悻悱惝惘惆惚悴愠愦愕愣惴愀愎愫慊慵憬憔憧憷懔懵忝隳闩闫闱闳闵闶闼闾阃阄阆阈阊阋阌阍阏阒阕阖阗阙阚丬爿戕氵汔汜汊沣沅沐沔沌汨汩汴汶沆沩泐泔沭泷泸泱泗沲泠泖泺泫泮沱泓泯泾洹洧洌浃浈洇洄洙洎洫浍洮洵洚浏浒浔洳涑浯涞涠浞涓涔浜浠浼浣渚淇淅淞渎涿淠渑淦淝淙渖涫渌涮渫湮湎湫溲湟溆湓湔渲渥湄滟溱溘滠漭滢溥溧溽溻溷滗溴滏溏滂" +
          "溟潢潆潇漤漕滹漯漶潋潴漪漉漩澉澍澌潸潲潼潺濑濉澧澹澶濂濡濮濞濠濯瀚瀣瀛瀹瀵灏灞宀宄宕宓宥宸甯骞搴寤寮褰寰蹇謇辶迓迕迥迮迤迩迦迳迨逅逄逋逦逑逍逖逡逵逶逭逯遄遑遒遐遨遘遢遛暹遴遽邂邈邃邋彐彗彖彘尻咫屐屙孱屣屦羼弪弩弭艴弼鬻屮妁妃妍妩妪妣妗姊妫妞妤姒妲妯姗妾娅娆姝娈姣姘姹娌娉娲娴娑娣娓婀婧婊婕娼婢婵胬媪媛婷婺媾嫫媲嫒嫔媸嫠嫣嫱嫖嫦嫘嫜嬉嬗嬖嬲嬷孀尕尜孚孥孳孑孓孢驵驷驸驺驿驽骀骁骅骈骊骐骒骓骖骘骛骜骝骟骠骢骣骥骧纟纡纣纥纨纩纭纰纾绀绁绂绉绋绌绐绔绗绛绠绡绨绫绮绯绱绲缍绶绺绻绾缁缂缃" + "缇缈缋缌缏缑缒缗缙缜缛缟缡缢缣缤缥缦缧缪缫缬缭缯缰缱缲缳缵幺畿巛甾邕玎玑玮玢玟珏珂珑玷玳珀珉珈珥珙顼琊珩珧珞玺珲琏琪瑛琦琥琨琰琮琬琛琚瑁瑜瑗瑕瑙瑷瑭瑾璜璎璀璁璇璋璞璨璩璐璧瓒璺韪韫韬杌杓杞杈杩枥枇杪杳枘枧杵枨枞枭枋杷杼柰栉柘栊柩枰栌柙枵柚枳柝栀柃枸柢栎柁柽栲栳桠桡桎桢桄桤梃栝桕桦桁桧桀栾桊桉栩梵梏桴桷梓桫棂楮棼椟椠棹椤棰椋椁楗棣椐楱椹楠楂楝榄楫榀榘楸椴槌榇榈槎榉楦楣楹榛榧榻榫榭槔榱槁槊槟榕槠榍槿樯槭樗樘橥槲橄樾檠橐橛樵檎橹樽樨橘橼檑檐檩檗檫猷獒殁殂殇殄殒殓殍殚殛殡殪轫轭轱轲轳轵轶" +
          "轸轷轹轺轼轾辁辂辄辇辋辍辎辏辘辚軎戋戗戛戟戢戡戥戤戬臧瓯瓴瓿甏甑甓攴旮旯旰昊昙杲昃昕昀炅曷昝昴昱昶昵耆晟晔晁晏晖晡晗晷暄暌暧暝暾曛曜曦曩贲贳贶贻贽赀赅赆赈赉赇赍赕赙觇觊觋觌觎觏觐觑牮犟牝牦牯牾牿犄犋犍犏犒挈挲掰搿擘耄毪毳毽毵毹氅氇氆氍氕氘氙氚氡氩氤氪氲攵敕敫牍牒牖爰虢刖肟肜肓肼朊肽肱肫肭肴肷胧胨胩胪胛胂胄胙胍胗朐胝胫胱胴胭脍脎胲胼朕脒豚脶脞脬脘脲腈腌腓腴腙腚腱腠腩腼腽腭腧塍媵膈膂膑滕膣膪臌朦臊膻臁膦欤欷欹歃歆歙飑飒飓飕飙飚殳彀毂觳斐齑斓於旆旄旃旌旎旒旖炀炜炖炝炻烀炷炫炱烨烊焐焓焖焯焱" +
          "煳煜煨煅煲煊煸煺熘熳熵熨熠燠燔燧燹爝爨灬焘煦熹戾戽扃扈扉礻祀祆祉祛祜祓祚祢祗祠祯祧祺禅禊禚禧禳忑忐怼恝恚恧恁恙恣悫愆愍慝憩憝懋懑戆肀聿沓泶淼矶矸砀砉砗砘砑斫砭砜砝砹砺砻砟砼砥砬砣砩硎硭硖硗砦硐硇硌硪碛碓碚碇碜碡碣碲碹碥磔磙磉磬磲礅磴礓礤礞礴龛黹黻黼盱眄眍盹眇眈眚眢眙眭眦眵眸睐睑睇睃睚睨睢睥睿瞍睽瞀瞌瞑瞟瞠瞰瞵瞽町畀畎畋畈畛畲畹疃罘罡罟詈罨罴罱罹羁罾盍盥蠲钅钆钇钋钊钌钍钏钐钔钗钕钚钛钜钣钤钫钪钭钬钯钰钲钴钶钷钸钹钺钼钽钿铄铈铉铊铋铌铍铎铐铑铒铕铖铗铙铘铛铞铟铠铢铤铥铧铨铪铩铫铮铯铳铴铵铷铹铼" +
          "铽铿锃锂锆锇锉锊锍锎锏锒锓锔锕锖锘锛锝锞锟锢锪锫锩锬锱锲锴锶锷锸锼锾锿镂锵镄镅镆镉镌镎镏镒镓镔镖镗镘镙镛镞镟镝镡镢镤镥镦镧镨镩镪镫镬镯镱镲镳锺矧矬雉秕秭秣秫稆嵇稃稂稞稔稹稷穑黏馥穰皈皎皓皙皤瓞瓠甬鸠鸢鸨鸩鸪鸫鸬鸲鸱鸶鸸鸷鸹鸺鸾鹁鹂鹄鹆鹇鹈鹉鹋鹌鹎鹑鹕鹗鹚鹛鹜鹞鹣鹦鹧鹨鹩鹪鹫鹬鹱鹭鹳疒疔疖疠疝疬疣疳疴疸痄疱疰痃痂痖痍痣痨痦痤痫痧瘃痱痼痿瘐瘀瘅瘌瘗瘊瘥瘘瘕瘙瘛瘼瘢瘠癀瘭瘰瘿瘵癃瘾瘳癍癞癔癜癖癫癯翊竦穸穹窀窆窈窕窦窠窬窨窭窳衤衩衲衽衿袂裆袷袼裉裢裎裣裥裱褚裼裨裾裰褡褙褓褛褊褴褫褶襁襦疋胥皲皴矜耒" +
          "耔耖耜耠耢耥耦耧耩耨耱耋耵聃聆聍聒聩聱覃顸颀颃颉颌颍颏颔颚颛颞颟颡颢颥颦虍虔虬虮虿虺虼虻蚨蚍蚋蚬蚝蚧蚣蚪蚓蚩蚶蛄蚵蛎蚰蚺蚱蚯蛉蛏蚴蛩蛱蛲蛭蛳蛐蜓蛞蛴蛟蛘蛑蜃蜇蛸蜈蜊蜍蜉蜣蜻蜞蜥蜮蜚蜾蝈蜴蜱蜩蜷蜿螂蜢蝽蝾蝻蝠蝰蝌蝮螋蝓蝣蝼蝤蝙蝥螓螯螨蟒蟆螈螅螭螗螃螫蟥螬螵螳蟋蟓螽蟑蟀蟊蟛蟪蟠蟮蠖蠓蟾蠊蠛蠡蠹蠼缶罂罄罅舐竺竽笈笃笄笕笊笫笏筇笸笪笙笮笱笠笥笤笳笾笞筘筚筅筵筌筝筠筮筻筢筲筱箐箦箧箸箬箝箨箅箪箜箢箫箴篑篁篌篝篚篥篦篪簌篾篼簏簖簋簟簪簦簸籁籀臾舁舂舄臬衄舡舢舣舭舯舨舫舸舻舳舴舾艄艉艋艏艚艟艨衾袅袈裘裟襞羝羟" +
          "羧羯羰羲籼敉粑粝粜粞粢粲粼粽糁糇糌糍糈糅糗糨艮暨羿翎翕翥翡翦翩翮翳糸絷綦綮繇纛麸麴赳趄趔趑趱赧赭豇豉酊酐酎酏酤酢酡酰酩酯酽酾酲酴酹醌醅醐醍醑醢醣醪醭醮醯醵醴醺豕鹾趸跫踅蹙蹩趵趿趼趺跄跖跗跚跞跎跏跛跆跬跷跸跣跹跻跤踉跽踔踝踟踬踮踣踯踺蹀踹踵踽踱蹉蹁蹂蹑蹒蹊蹰蹶蹼蹯蹴躅躏躔躐躜躞豸貂貊貅貘貔斛觖觞觚觜觥觫觯訾謦靓雩雳雯霆霁霈霏霎霪霭霰霾龀龃龅龆龇龈龉龊龌黾鼋鼍隹隼隽雎雒瞿雠銎銮鋈錾鍪鏊鎏鐾鑫鱿鲂鲅鲆鲇鲈稣鲋鲎鲐鲑鲒鲔鲕鲚鲛鲞鲟鲠鲡鲢鲣鲥鲦鲧鲨鲩鲫鲭鲮鲰鲱鲲鲳鲴鲵鲶鲷鲺鲻鲼鲽鳄鳅鳆鳇鳊鳋鳌鳍鳎鳏鳐鳓鳔" + "鳕鳗鳘鳙鳜鳝鳟鳢靼鞅鞑鞒鞔鞯鞫鞣鞲鞴骱骰骷鹘骶骺骼髁髀髅髂髋髌髑魅魃魇魉魈魍魑飨餍餮饕饔髟髡髦髯髫髻髭髹鬈鬏鬓鬟鬣麽麾縻麂麇麈麋麒鏖麝麟黛黜黝黠黟黢黩黧黥黪黯鼢鼬鼯鼹鼷鼽鼾齄";
            byte[] array = new byte[2];
            string return_py = "";
            for (int i = 0; i < text.Length; i++)
            {
                array = System.Text.Encoding.Default.GetBytes(text[i].ToString());
                if (array[0] < 176)  //.非汉字  
                {
                    return_py += text[i];
                }
                else if (array[0] >= 176 && array[0] <= 215)  //一级汉字  
                {
                    if (text[i].ToString().CompareTo("匝") >= 0)
                        return_py += "z";
                    else if (text[i].ToString().CompareTo("压") >= 0)
                        return_py += "y";
                    else if (text[i].ToString().CompareTo("昔") >= 0)
                        return_py += "x";
                    else if (text[i].ToString().CompareTo("挖") >= 0)
                        return_py += "w";
                    else if (text[i].ToString().CompareTo("塌") >= 0)
                        return_py += "t";
                    else if (text[i].ToString().CompareTo("撒") >= 0)
                        return_py += "s";
                    else if (text[i].ToString().CompareTo("然") >= 0)
                        return_py += "r";
                    else if (text[i].ToString().CompareTo("期") >= 0)
                        return_py += "q";
                    else if (text[i].ToString().CompareTo("啪") >= 0)
                        return_py += "p";
                    else if (text[i].ToString().CompareTo("哦") >= 0)
                        return_py += "o";
                    else if (text[i].ToString().CompareTo("拿") >= 0)
                        return_py += "n";
                    else if (text[i].ToString().CompareTo("妈") >= 0)
                        return_py += "m";
                    else if (text[i].ToString().CompareTo("垃") >= 0)
                        return_py += "l";
                    else if (text[i].ToString().CompareTo("喀") >= 0)
                        return_py += "k";
                    else if (text[i].ToString().CompareTo("击") >= 0)
                        return_py += "j";
                    else if (text[i].ToString().CompareTo("哈") >= 0)
                        return_py += "h";
                    else if (text[i].ToString().CompareTo("噶") >= 0)
                        return_py += "g";
                    else if (text[i].ToString().CompareTo("发") >= 0)
                        return_py += "f";
                    else if (text[i].ToString().CompareTo("蛾") >= 0)
                        return_py += "e";
                    else if (text[i].ToString().CompareTo("搭") >= 0)
                        return_py += "d";
                    else if (text[i].ToString().CompareTo("擦") >= 0)
                        return_py += "c";
                    else if (text[i].ToString().CompareTo("芭") >= 0)
                        return_py += "b";
                    else if (text[i].ToString().CompareTo("啊") >= 0)
                        return_py += "a";
                }
                else if (array[0] >= 215)    //二级汉字  
                {
                    return_py += ls_second_eng.Substring(ls_second_ch.IndexOf(text[i].ToString(), 0), 1);
                }
            }
            return return_py.ToLower();
        }

        /// <summary>
        /// 从字符串的指定位置截取指定长度的子字符串
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <param name="length">子字符串的长度</param>
        /// <param name="startIndex">子字符串的起始位置</param>
        /// <returns>子字符串</returns>
        public static string FormatCut(this string str, int length, int startIndex = 0)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;

            if (startIndex >= 0)
            {
                if (length < 0)
                {
                    length = length * -1;
                    if (startIndex - length < 0)
                    {
                        length = startIndex;
                        startIndex = 0;
                    }
                    else
                        startIndex = startIndex - length;
                }

                if (startIndex > str.Length)
                    return "";
            }
            else
            {
                if (length < 0)
                    return "";
                else
                {
                    if (length + startIndex > 0)
                    {
                        length = length + startIndex;
                        startIndex = 0;
                    }
                    else
                        return "";
                }
            }

            if (str.Length - startIndex < length)
                length = str.Length - startIndex;

            return str.Substring(startIndex, length);
        }

        /// <summary>
        /// 左截取
        /// </summary>
        /// <param name="str"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string Left(this string str, int len)
        {
            if (str == null)
            {
                throw new ArgumentNullException("str");
            }

            if (str.Length < len)
            {
                throw new ArgumentException("len argument can not be bigger than given string's length!");
            }

            return str.Substring(0, len);
        }

        /// <summary>
        /// 右截取
        /// </summary>
        /// <param name="str"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string Right(this string str, int len)
        {
            if (str == null)
            {
                throw new ArgumentNullException("str");
            }

            if (str.Length < len)
            {
                throw new ArgumentException("len argument can not be bigger than given string's length!");
            }

            return str.Substring(str.Length - len, len);
        }

        /// <summary>
        /// 移除开始标点符号
        /// </summary>
        public static string TrimStartPunctuation(this string str)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                return str.TrimStart('。', '，', '、', '＇', '：', '∶', '；', '?', '\'', '‘', '’', '“', '”', '〝', '〞', 'ˆ', 'ˇ', '﹕', '︰', '﹔', '﹖', '﹑', '·', '¨', '…', '.', '¸', ';', '！', '´', '？', '！', '～', '—', 'ˉ');
            }
            return str;
        }

        /// <summary>
        /// 移除结束标点符号
        /// </summary>
        public static string TrimEndPunctuation(this string str)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                return str.TrimStart('。', '，', '、', '＇', '：', '∶', '；', '?', '\'', '‘', '’', '“', '”', '〝', '〞', 'ˆ', 'ˇ', '﹕', '︰', '﹔', '﹖', '﹑', '·', '¨', '…', '.', '¸', ';', '！', '´', '？', '！', '～', '—', 'ˉ');
            }
            return str;
        }

        /// <summary>
        /// 移除后面第一个后缀（ApiControllerController,移除后->ApiController）
        /// </summary>
        public static string RemovePostFix(this string str, params string[] postFixes)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return "";
            }

            if (postFixes == null || (postFixes != null && postFixes.Length == 0))
            {
                return str;
            }

            foreach (var postFix in postFixes)
            {
                if (str.EndsWith(postFix, StringComparison.CurrentCultureIgnoreCase))
                {
                    return str.Left(str.Length - postFix.Length);
                }
            }

            return str;
        }

        /// <summary>
        /// 移除前面第一个前缀（ApiApiController,移除后->ApiController）
        /// </summary>
        public static string RemovePreFix(this string str, params string[] preFixes)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return "";
            }

            if (preFixes == null || (preFixes != null && preFixes.Length == 0))
            {
                return str;
            }

            foreach (var preFix in preFixes)
            {
                if (str.StartsWith(preFix, StringComparison.CurrentCultureIgnoreCase))
                {
                    return str.Right(str.Length - preFix.Length);
                }
            }

            return str;
        }

        #endregion

        #region 验证判断

        /// <summary>
        /// 指示所指定的正则表达式在指定的输入字符串中是否找到了匹配项
        /// </summary>
        /// <param name="value">要搜索匹配项的字符串</param>
        /// <param name="pattern">要匹配的正则表达式模式</param>
        /// <param name="isContains">是否包含，否则全匹配</param>
        /// <returns>如果正则表达式找到匹配项，则为 true；否则，为 false</returns>
        public static bool IsMatch(string value, string pattern, bool isContains = true)
        {
            if (value == null)
            {
                return false;
            }
            return isContains
                ? Regex.IsMatch(value, pattern)
                : Regex.Match(value, pattern).Success;
        }

        /// <summary>
        /// 判断是否为IP地址
        /// </summary>
        public static bool IsIP(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return false;
            return Regex.IsMatch(str, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        /// <summary>
        /// 验证是否邮箱地址
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEmail(this string str)
        {
            const string pattern = @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$";
            return IsMatch(str, pattern);
        }

        /// <summary>
        /// 验证是否联系电话(座机或手机号码)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsTelphone(this string str)
        {
            return IsMobile(str) || IsPhone(str);
        }

        /// <summary>
        /// 验证是否手机号码
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isRestrict"></param>
        /// <returns></returns>
        public static bool IsMobile(this string str, bool isRestrict = false)
        {
            string pattern = isRestrict ? @"^[1][3-8]\d{9}$" : @"^[1]\d{10}$";
            return IsMatch(str, pattern);
        }

        /// <summary>
        /// 验证是否电话号码(区号[3-4位]-数字[6-8位])
        /// </summary>
        /// <returns></returns>
        public static bool IsPhone(this string str)
        {
            return IsMatch(str, @"^(\d{3,4}-)?\d{6,8}$");
        }

        /// <summary>
        /// 是否身份证号，验证如下3种情况：
        /// 1.身份证号码为15位数字；
        /// 2.身份证号码为18位数字；
        /// 3.身份证号码为17位数字+1个字母
        /// </summary>
        public static bool IsIdentityCard(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return false;

            if (str.Length != 15 && str.Length != 18)
            {
                return false;
            }
            Regex regex;
            string[] array;
            DateTime time;
            if (str.Length == 15)
            {
                regex = new Regex(@"^(\d{6})(\d{2})(\d{2})(\d{2})(\d{3})_");
                if (!regex.Match(str).Success)
                {
                    return false;
                }
                array = regex.Split(str);
                return DateTime.TryParse(string.Format("{0}-{1}-{2}", "19" + array[2], array[3], array[4]), out time);
            }
            regex = new Regex(@"^(\d{6})(\d{4})(\d{2})(\d{2})(\d{3})([0-9Xx])$");
            if (!regex.Match(str).Success)
            {
                return false;
            }
            array = regex.Split(str);
            if (!DateTime.TryParse(string.Format("{0}-{1}-{2}", array[2], array[3], array[4]), out time))
            {
                return false;
            }
            //校验最后一位
            string[] chars = str.ToCharArray().Select(m => m.ToString()).ToArray();
            int[] weights = { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                int num = int.Parse(chars[i]);
                sum = sum + num * weights[i];
            }
            int mod = sum % 11;
            string vCode = "10X98765432";//检验码字符串
            string last = vCode.ToCharArray().ElementAt(mod).ToString();
            return chars.Last().ToUpper() == last;
        }

        /// <summary>
        /// 是否是Unicode字符串
        /// </summary>
        public static bool IsUnicode(this string str)
        {
            const string pattern = @"^[\u4E00-\u9FA5\uE815-\uFA29]+$";
            return IsMatch(str, pattern);
        }

        /// <summary>
        /// 是否Url字符串
        /// </summary>
        public static bool IsUrl(this string str)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(str))
                {
                    return false;
                }
                Uri uri = new Uri(str);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 两个字符串是否相等
        /// </summary>
        public static bool IsEqual(this string str, string strB, bool ignoreCase = true, bool canNullOrEmpty = false)
        {
            if (!canNullOrEmpty && (string.IsNullOrWhiteSpace(str) || string.IsNullOrWhiteSpace(strB)))
                return false;

            return string.Compare(str, strB, ignoreCase) == 0;
        }

        /// <summary>
        /// 结束是否为标点符号
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEndPunctuation(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return false;

            return Punctuations.Contains(str.Substring(str.Length - 1, 1));
        }

        #endregion

        #region 辅助操作(GetByXXX,GetToXXX,GetByXXXXToXXX,SetXXX,......)

        /// <summary>
        /// 获取字符串数组
        /// </summary>
        public static string[] GetToArray(object obj, string[] separator = null, bool isRemoveEmpty = true)
        {
            if (obj == null)
                return new string[] { };

            if (separator == null || (separator != null && separator.Count() == 0))
            {
                separator = new string[] { "," };
            }
            return Get(obj).Split(separator, isRemoveEmpty ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None);
        }

        /// <summary>
        /// 获取货币格式字符串
        /// </summary>
        /// <param name="value">货币值</param>
        /// <param name="format">格式</param>
        /// <returns>货币字符串</returns>
        public static string GetToMoney(decimal value, string format = "N")
        {
            return value.ToString("f2");
        }

        /// <summary>
        /// 将数组内容转为sql in 内容格式 eg:'','',.....
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="hasQuote"></param>
        /// <returns></returns>
        public static string GetToSqlField<T>(T[] arr, bool hasQuote = true)
        {
            if (arr == null && (arr != null || arr.Length == 0))
            {
                return string.Empty;
            }

            var itemFormat = "{0},"; //"{0},"整数等
            if (hasQuote)
            {
                itemFormat = "'{0}',";
            }

            StringBuilder build = new StringBuilder();
            foreach (var item in arr)
            {
                build.AppendFormat(itemFormat, item);
            }
            if (build.Length > 0)
            {
                //build.TrimEnd(',');
            }
            return build.ToString();
        }

        /// <summary>
        /// 获取字符串列表
        /// eg: aaa=xxxx;b=xxxx;c=xxx,xxx;  以;分割,值多个以,分割
        /// </summary>
        public static List<KeyValues> GetToListByForm(string str, char listSplit = ';', char valueSplit = '=')
        {
            List<KeyValues> list = new List<KeyValues>();
            string[] items = new string[0];
            if (!string.IsNullOrWhiteSpace(str))
            {
                items = str.Split(listSplit);
            }
            if (items.Length > 0)
            {
                items.ToList().ForEach(x =>
                {
                    if (!string.IsNullOrWhiteSpace(x))
                    {
                        x = x.Trim();
                        string key = "", value = "";
                        var values = x.Split(valueSplit);
                        if (values.Length > 0)
                        {
                            key = values[0];
                        }
                        if (values.Length > 1)
                        {
                            value = values[1];
                        }
                        if (!string.IsNullOrWhiteSpace(key))
                        {
                            list.Add(new KeyValues(key, value));
                        }
                    }
                });
            }
            return list;
        }

        /// <summary>
        /// KeyValue列表转为{0}={1} {2}={3}....格式
        /// </summary>
        /// <param name="list"></param>
        /// <param name="isUrlEncoding">值Value是否进行Url编码</param>
        /// <returns></returns>
        public static string GetFormByList(List<KeyValues> list, bool isUrlEncoding = true)
        {
            if (list == null || (list != null && list.Count == 0))
                return "";

            StringBuilder builder = new StringBuilder();
            list.ForEach((x) => builder.AppendFormat("{0}={1}&", x.Key, isUrlEncoding ? System.Net.WebUtility.UrlEncode(x.Value) : x.Value));
            if (builder.Length > 0)
            {
                builder = builder.Remove(builder.Length - 1, 1);
            }
            return builder.ToString();
        }

        /// <summary>
        /// 将字符串转为Byte[]
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static byte[] GetToBytes(string str, Encoding encoding = null)
        {
            if (string.IsNullOrWhiteSpace(str))
                return null;

            if (encoding == null)
                encoding = Encoding.UTF8;

            return encoding.GetBytes(str);
        }

        /// <summary>
        /// 获取拼音信息
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static PinYinModel GetPinYin(string str)
        {
            var chs = str.ToCharArray();
            //记录每个汉字的全拼
            Dictionary<int, List<string>> totalPingYins = new Dictionary<int, List<string>>();
            for (int i = 0; i < chs.Length; i++)
            {
                var pinyins = new List<string>();
                var ch = chs[i];
                //是否是有效的汉字
                if (ChineseChar.IsValidChar(ch))
                {
                    ChineseChar cc = new ChineseChar(ch);
                    pinyins = cc.Pinyins.Where(p => !string.IsNullOrWhiteSpace(p)).ToList();
                }
                else
                {
                    pinyins.Add(ch.ToString());
                }

                //去除声调，转小写
                pinyins = pinyins.ConvertAll(p => Regex.Replace(p, @"\d", "").ToLower());
                //去重
                pinyins = pinyins.Where(p => !string.IsNullOrWhiteSpace(p)).Distinct().ToList();
                if (pinyins.Any())
                {
                    totalPingYins[i] = pinyins;
                }
            }

            PinYinModel result = new PinYinModel();
            foreach (var pinyins in totalPingYins)
            {
                var items = pinyins.Value;
                if (result.Spells.Count <= 0)
                {
                    result.Spells = items;
                    result.Shorts = items.ConvertAll(p => p.Substring(0, 1)).Distinct().ToList();
                }
                else
                {
                    //全拼循环匹配
                    var newTotalPingYins = new List<string>();
                    foreach (var totalPingYin in result.Spells)
                    {
                        newTotalPingYins.AddRange(items.Select(item => totalPingYin + item));
                    }
                    newTotalPingYins = newTotalPingYins.Distinct().ToList();
                    result.Spells = newTotalPingYins;

                    //首字母循环匹配
                    var newFirstPingYins = new List<string>();
                    foreach (var firstPingYin in result.Shorts)
                    {
                        newFirstPingYins.AddRange(items.Select(item => firstPingYin + item.Substring(0, 1)));
                    }
                    newFirstPingYins = newFirstPingYins.Distinct().ToList();
                    result.Shorts = newFirstPingYins;
                }
            }
            return result;
        }

        #endregion

    }

    public class PinYinModel
    {
        public List<string> Spells { get; set; } = new List<string>();

        public List<string> Shorts { get; set; } = new List<string>();

        public string Spell { get { return Spells.Count() > 0 ? Spells.FirstOrDefault() : ""; } }

        public string Short { get { return Shorts.Count() > 0 ? Shorts.FirstOrDefault() : ""; } }
    }
}
