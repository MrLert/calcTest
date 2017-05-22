using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ClassLibrary;
using WebCalcNew.Managers;
using WebCalcNew.Models;

namespace WebCalcNew.Controllers
{
    public class CalcController : Controller
    {
        #region Private region
        private IEnumerable<SelectListItem> OperationsList { get; set; }
        private Calc Calc { get; set; }
        private IOperationResultRepository OperationResultRepository { get; set; }

        #endregion

        // GET: Calc
        public CalcController()
        {
            Calc = new Calc(@"C:\Users\Дмитрий\Documents\Visual Studio 2017\Projects\CalcTest\WebCalcNew\bin");
            OperationsList = Calc.operations.Select(o => new SelectListItem() { Text = $"{o.GetType().Name}.{o.Name}", Value = $"{o.GetType().Name}.{o.Name}" });
            OperationResultRepository = new EFOperResultRepository();
        }
        public ActionResult Index()
        {
            var model = new OperationViewModel(OperationsList);
            return View(model);
        }
        [HttpPost]
        
        public ActionResult Index(OperationViewModel model, CheckBox checkB)
        {
            
            #region Поиск в базе
            var operResult = OperationResultRepository.GetAll();
            var oldResult =
                operResult.FirstOrDefault(x => x.OperationName == model.Operation && x.Arguments == model.InputData.Trim());
            #endregion

            if (oldResult != null && checkB != null)
            {
                model.Result =
                    $"Уже вычисляли {oldResult.ExecutionDate} (заняло {oldResult.ExecutionTime}мс.) и получили {oldResult.Result}";

            }
            else
            {

                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var names = model.Operation.Split('.');
                var opers = Calc.operations.Where(o => o.Name == names[1]);
                var oper = opers.FirstOrDefault(o => o.GetType().Name == names[0]);
                var result = Calc.Execute(oper, model.InputData.Split(' '));
                Thread.Sleep(new Random().Next(1, 100));
                stopWatch.Stop();

                var operRes = new OperationResult
                {
                    OperationName = model.Operation,
                    Result = result as double?,
                    Arguments = model.InputData.Trim(),
                    ExecutionTime = stopWatch.ElapsedMilliseconds * 10,
                    ExecutionDate = DateTime.Now
                };
                if (checkB == null && oldResult != null)
                {
                    OperationResultRepository.Update(operRes);
                    model.Result = $"Пересчитано и получено {result}";
                }
                else
                {
                    OperationResultRepository.Save(operRes);
                    model.Result = $"{result}";
                }

            }
            model.Operations = OperationsList;
            return View(model);
        }
    }
}