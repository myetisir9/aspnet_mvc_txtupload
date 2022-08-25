using aspnet_mvc.Models;
using Business.Abstract;
using Business.Concrete;
using Business.Concrete.CommingText;
using DataAccess.Concrete;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using System.Globalization;

namespace aspnet_mvc.Helper
{
    public class ComingTextHelper
    {
        private static ComingTextHelper _comingTextHelper;

        private ICommingTextService _commingTextService;

        public List<ComingTextModel> list;

        public static ComingTextHelper GetInstance()
        {
            if (_comingTextHelper == null)
                _comingTextHelper = new ComingTextHelper();
            return _comingTextHelper;
        }

        public int errorCode { get; set; }
        public String ErrorMessage { get; set; }
        public List<ComingTextModel> GetAll(string fileurl)
        {
            errorCode = 200;
            ErrorMessage = null;

            list = new List<ComingTextModel>();

            FileStream fileStream = new FileStream(fileurl, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(fileStream);
            string readcontents = reader.ReadToEnd();

            string[] lines = readcontents.Split(
                new string[] { Environment.NewLine },
                StringSplitOptions.None
            );

            for (int i = 0; i < lines.Length; i++)
            {
                try
                {
                    string[] words = lines[i].Split(',');
                    //list.Add(new ComingTextModel(words[0], words[1], words[2], words[3], words[4], words[5], words[6], words[7], words[8]));
                    list.Add(new ComingTextModel
                    {
                        RemainingVacation = int.Parse(words[0], NumberStyles.AllowLeadingSign),
                        Name = words[1].ToString(),
                        Surname = words[2].ToString(),
                        EarnedVacation = int.Parse(words[3]),
                        Salary = int.Parse(words[4]),
                        Branch = words[5].ToString(),
                        Department = words[6].ToString(),
                        YearsWorked = Convert.ToInt32(words[7].ToString()),
                        WantsToAddVacations = Convert.ToBoolean(words[8].ToString())

                    });



                }
                catch (Exception ex)
                {
                    errorCode = ex.GetHashCode();
                    ErrorMessage = ex.Message;
                }
            }
            return list;

        }

        public bool AddNewDatabase()
        {
            try
            {
                if (list.Count > 0)
                {
                    _commingTextService = new CommingTextManager(new CommingTextDal());
                    list.ForEach(p =>
                    {
                        CommingTextManagerHelper.Add(JsonConvert.SerializeObject(p), _commingTextService);
                    });
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<ComingTextModel> GetAllDatabase()
        {
            if (list==null)
            {
                _commingTextService = new CommingTextManager(new CommingTextDal());
                list = JsonConvert.DeserializeObject<List<ComingTextModel>>(CommingTextManagerHelper.GetAll(_commingTextService));
            }
            return list;

        }
    }
}
