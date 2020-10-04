using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LearningASP.DataServices;

namespace LearningASP.CommonCode
{
    public static class DataContextHelper
    {
        public static LearningASPDB GetDataContext(bool enableAutoSelect = true)
        {
            return GetNewDataContext("LearningASPDB", enableAutoSelect);
        }
        private static LearningASPDB GetNewDataContext(string connStringName, bool enableAutoSelect)
        {
            LearningASPDB dataRepository = new LearningASPDB(connStringName);
            dataRepository.EnableAutoSelect = enableAutoSelect;
            return dataRepository;

        }
    }
}