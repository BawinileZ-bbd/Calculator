using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using CalculatorAPI.Models;


namespace CalculatorAPI.Controllers
{   
    public class TrigFunctionController
    {
          [HttpPost("TrigFunctions")]
        public async Task<IActionResult> getInputs([FromBody] TrigPostRequest trig)
        {
            
            
            TrigPostRequest d = new  TrigPostRequest();
            List<Trig> ls= trig.Tags;
       


            //assume the inputs are already validated:
            string answer = null;
            foreach (Trig obj in ls){
                if(obj.trigFunction == "sin"){
                    answer = answer + obj.sign +  Math.Round(Math.Sin(obj.degreeValue*Math.PI / 180.0), 2);
                }

                if(obj.trigFunction == "cos"){
                    answer = answer + obj.sign + Math.Round(Math.Cos(obj.degreeValue*Math.PI / 180.0),2);
                }

                if(obj.trigFunction == "tan"){
                    answer = answer +obj.sign +Math.Round(Math.Tan(obj.degreeValue*Math.PI / 180.0),2);
                }
            }        
            return new ObjectResult(Eval(answer.Replace(",", ".")));

        }
    static Double Eval(String expression)
    {
        System.Data.DataTable table = new System.Data.DataTable();
        return Convert.ToDouble(table.Compute(expression, String.Empty));
    }
    }
}