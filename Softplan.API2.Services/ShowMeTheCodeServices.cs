using Softplan.API2.Domain.Entities;
using Softplan.API2.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Softplan.API2.Services
{
    public class ShowMeTheCodeServices : IShowMeTheCodeServices
    {
        #region Construtor

        public ShowMeTheCodeServices()
        {

        }

        #endregion

        #region Metodos

        public ShowMeTheCodeDTO GetURLGit()
        {
            ShowMeTheCodeDTO url = new ShowMeTheCodeDTO()
            { 
                URLGit = "https://github.com/julianoalm/SoftplanAPI.git"
            };

            return url;
        }

        #endregion
    }
}
