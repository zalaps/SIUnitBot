using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Luis.Models;
using UnitsNet;
using Bot_Application1.Helpers;

namespace Bot_Application1.Dialogs
{
    [LuisModel("7cd60eff-1d44-4bc7-89b3-c8c9191828fb", "9deb3d4e61014f05b8748cba69b65570")]
    [Serializable]
    public class DefaultLuisDialog : LuisDialog<object>
    {
        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Sorry, I don't know what you wanted.");
            context.Wait(MessageReceived);
        }
        [LuisIntent("ConvertUnits")]
        public async Task ConvertUnit(IDialogContext context, LuisResult result)
        {
            string[] measure = result.Entities.Where(x => x.Type == "Measure").FirstOrDefault().Entity.Split(' ');

            string[] unit = result.Entities.Where(x => x.Type == "ToMeasure").FirstOrDefault().Entity.Split(' ');

            var fromAmount = measure[0];

            var massType = measure[1];

            string returnMessage = UnitConversionHelper.Convert(Convert.ToDouble(fromAmount), massType, unit[1]);

            var entities = new List<EntityRecommendation>(result.Entities);

            await context.PostAsync(returnMessage);

            context.Wait(MessageReceived);
        }
    }
}