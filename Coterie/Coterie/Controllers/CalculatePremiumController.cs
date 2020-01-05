using Coterie_Data;
using Coterie_Models;
using Coterie_Models.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Coterie.Controllers
{
    public class CalculatePremiumController : ApiController
    {
        public IHttpActionResult Get(UserProfile userProfile)
        {
            var baseFactor = ConfigurationManager.AppSettings["BaseFactor"].ToDecimal(0);
            var hazardFactor = ConfigurationManager.AppSettings["HazardFactor"].ToDecimal(0);
            var stateFactor = Read.StateFactor(userProfile.State);
            var businessFactor = Read.BusinessFactor(userProfile.Business);

            var premium = new CalculatedPremium(userProfile.Revenue, businessFactor, stateFactor, baseFactor, hazardFactor);

            if(premium.Premium <= 0)
            {
                return BadRequest("An error occurred in calculation");
            }

            return Ok(premium);
        }
    }
}
