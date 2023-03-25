using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ReactiveUI;
using RevaloniaAddin.Addins.Models;

namespace RevaloniaAddin.Addins.ViewModels
{
    public class MainViewModel : ReactiveObject
    {
        public ExternalEvent LevelDifferenceEvent { get; set; }
        public ExternalEvent ReselectFirstPointEvent { get; set; }
        public ExternalEvent ReselectSecondPointEvent { get; set; }
        public ExternalEvent DeleteSelectedSpotDimsEvent { get; set; }


        private double firstPoint;
        private double sedondPoint;
        private ElementId firstPointElementId;
        private ElementId secondPointElementId;
        private double levelDifference;
        private string firstPointDisplay;
        private string secondPointDisplay;
        private string levelDifferenceDisplay;
        private bool canPressReselect;
        private bool canPressDelete;




        public void TwoSpotsElevation()
        {
            LevelDifferenceEvent.Raise();
        }

        public void ReselectFirstPoint()
        {
            ReselectFirstPointEvent.Raise();
        }

        public void ReselectSecondPoint()
        {
            ReselectSecondPointEvent.Raise();
        }

        public void DeleteSelectedsSpotDims()
        {
            DeleteSelectedSpotDimsEvent.Raise();
        }


        public bool CanPressReselect
        {
            get => canPressReselect;
            set
            { 
                this.RaiseAndSetIfChanged(ref canPressReselect, value);

            }
        }

        public bool CanPressDelete
        {
            get => canPressDelete;
            set
            {
                this.RaiseAndSetIfChanged(ref canPressDelete, value);
            }
        }
        public string LevelDifferenceDisplay
        {
            get => levelDifferenceDisplay;
            set => this.RaiseAndSetIfChanged(ref levelDifferenceDisplay, value);
        }

        public string FirstPointDisplay
        {
            get => firstPointDisplay;
            set => this.RaiseAndSetIfChanged(ref firstPointDisplay, value);
        }

        public string SecondPointDisplay
        {
            get => secondPointDisplay;
            set => this.RaiseAndSetIfChanged(ref secondPointDisplay, value);
        }

        public double FirstPoint
        {
            get => firstPoint;
            set => this.RaiseAndSetIfChanged(ref firstPoint, value);
        }

        public double SecondPoint
        {
            get => sedondPoint;
            set => this.RaiseAndSetIfChanged(ref sedondPoint, value);
        }

        public ElementId FirstPointElementId
        {
            get => firstPointElementId;
            set => this.RaiseAndSetIfChanged(ref firstPointElementId, value);
        }

        public ElementId SecondPointElementId
        {
            get => secondPointElementId;
            set => this.RaiseAndSetIfChanged(ref secondPointElementId, value);
        }
        public double LevelDifference
        {
            get => levelDifference;
            set => this.RaiseAndSetIfChanged(ref levelDifference, value);
        }

    }
}
