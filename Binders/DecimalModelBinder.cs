using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormularioAspNetMvc.Binders
{
    //bind é o processo de ligação dos valor que são digitados pelo usuário
    //com as propriedades dos objetos que recebem esses valores
    public class DecimalModelBinder : IModelBinder
    {
        //ModelBinder customizado para converter o formato americano p/ brasilero
        public object BindModel( ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            ModelState modelState = new ModelState { Value = valueResult };
            object actualValue = null;
            try
            {
                //identifica o idioma atual da apligação, atraves do globalization dentro do webconfig
                actualValue = Convert.ToDecimal(valueResult.AttemptedValue, CultureInfo.CurrentCulture);
            }
            catch (FormatException e)
            {
                modelState.Errors.Add(e);
            }

            bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
            return actualValue;
        }
    }
}