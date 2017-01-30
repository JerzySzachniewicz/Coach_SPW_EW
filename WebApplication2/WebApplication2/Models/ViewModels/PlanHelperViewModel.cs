using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.ViewModels
{
    public class PlanHelperViewModel
    {
        public IEnumerable<TrainingPlan> Plans;
        public string Training;
        public string UsserClass;
        public PlanHelperViewModel(Results result)
        {
            Debug.Assert(result.Height != null, "result.Height != null");
            var bmi = result.Weights / Math.Pow(result.Height.Value / 100, 2);
            Debug.Assert(result.BodyFat != null, "result.BodyFat != null");
            var myClass = getPeapoleClass(bmi.Value, result.BodyFat.Value);
            var trainingType = GetTrainingType(myClass);
            Training = trainingType.Item1.ToString();
            UsserClass = trainingType.Item2+"";
            using (var db = new Model1())
            {
                var list =
                    db.TrainingPlan.Where(p => p.TrainingType.Name == Training && p.Level == trainingType.Item2)
                        .ToList();

                foreach (var temp in list)
                {
                    temp.TrainingType = db.GetTrainingTypeBtId(temp.Type.Value);
                }
                    Plans = list;
               
            }
        }

        private Tuple<TrainingType, int> GetTrainingType(PoepleClass people)
        {
            switch (people)
            {
                case PoepleClass.LowMassLowFat:
                    return new Tuple<TrainingType, int>(TrainingType.Basic, 2);
                case PoepleClass.LowMassNormalFat:
                    return new Tuple<TrainingType, int>(TrainingType.Basic, 2);
                case PoepleClass.LowMassHightFat:
                    return new Tuple<TrainingType, int>(TrainingType.Cardio, 1);
                case PoepleClass.NormalMassLowFat:
                    return new Tuple<TrainingType, int>(TrainingType.FBW, 4);
                case PoepleClass.NormalMassNormalFat:
                    return new Tuple<TrainingType, int>(TrainingType.FBW, 3);
                case PoepleClass.NormalMassHightFat:
                    return new Tuple<TrainingType, int>(TrainingType.Cardio, 2);
                case PoepleClass.HightMassLowFat:
                    return new Tuple<TrainingType, int>(TrainingType.SPLIT, 5);
                case PoepleClass.HightMassNormalFat:
                    return new Tuple<TrainingType, int>(TrainingType.SPLIT, 4);
                case PoepleClass.HightMassHightFat:
                    return new Tuple<TrainingType, int>(TrainingType.Cardio, 1);
                default:
                    throw new ArgumentOutOfRangeException(nameof(people), people, null);
            }
        }

        private PoepleClass getPeapoleClass(double bmi, double fat)
        {
            if (bmi < 18.5 && fat < 12)
                return PoepleClass.LowMassLowFat;

            if (bmi < 18.5 && fat >= 12 && fat < 25)
                return PoepleClass.LowMassNormalFat;

            if (bmi < 18.5 && fat >= 25)
                return PoepleClass.LowMassHightFat;

            if (bmi >= 18.5 && bmi < 25 && bmi < 23 && fat < 12)
                return PoepleClass.NormalMassLowFat;

            if (bmi >= 18.5 && bmi < 25 && fat >= 12 && fat < 25)
                return PoepleClass.NormalMassNormalFat;

            if (bmi >= 18.5 && bmi < 25 && fat >= 25)
                return PoepleClass.NormalMassHightFat;

            if (bmi >= 25 && bmi < 23 && fat < 12)
                return PoepleClass.HightMassLowFat;

            if (bmi >= 25 && fat > 12 && fat >= 12 && fat < 25)
                return PoepleClass.HightMassNormalFat;

            return PoepleClass.HightMassHightFat;
        }

        private enum PoepleClass
        {
            LowMassLowFat,
            LowMassNormalFat,
            LowMassHightFat,
            NormalMassLowFat,
            NormalMassNormalFat,
            NormalMassHightFat,
            HightMassLowFat,
            HightMassNormalFat,
            HightMassHightFat
        }

        private enum TrainingType
        {
            Cardio,
            Basic,
            FBW,
            SPLIT,
            Legs,
            Core,
            Arms,
            Chest
        }
    }
}