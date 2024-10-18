using Character.Controllers;
using Character.TrainSlots;
using UnityEngine;
using WRA.CharacterSystems;
using WRA.General.Patterns.Pool;

namespace Pool.Objects
{
    public class Train : CharacterObject
    {
        public TrainSlot[] TrainSlots => trainSlots;
        public TrainSlot SelectedSlot => selectedSlot;
        
        public MoneyController MoneyController { get; private set; }
        
        public ExpController ExpController { get; private set; }
        
        [SerializeField] private TrainSlot[] trainSlots;
        
        private TrainSlot selectedSlot;
        public override void OnInit()
        {
            MoneyController = GetComponent<MoneyController>();
            ExpController = GetComponent<ExpController>();
            
            foreach (var trainSlot in trainSlots)
            {
                trainSlot.SetTrain(this);
            }
        }

        public override void OnSpawn()
        {
            gameObject.SetActive(true);
        }

        public override void OnBeginKill(float delay)
        {
            
        }

        public override void OnKill()
        {
            
        }

        public void SelectSlot(int id)
        {
            SelectSlot(trainSlots[id]);
        }

        public void TakeControl(GameControlls gameControlls, int id)
        {
            ReleaseControl();
            SelectSlot(id);
            selectedSlot?.TurretAttached?.TurretBehaviour.TakeControl(gameControlls);
        }
        
        public void ReleaseControl()
        {
            foreach (var trainSlot in trainSlots)
            {
                trainSlot?.TurretAttached?.TurretBehaviour.ReleaseControl();
            }
        }
        
        public void SelectSlot(TrainSlot selectedSlot)
        {
            DeselectAllSlots();
            selectedSlot.SelectSlot();
            this.selectedSlot = selectedSlot;
        }
        
        public void DeselectAllSlots()
        {
            foreach (var trainSlot in trainSlots)
            {
                trainSlot.DeselectSlot();
            }
            selectedSlot = null;
        }
    }
}
