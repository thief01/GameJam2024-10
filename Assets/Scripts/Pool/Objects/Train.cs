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
        
        [SerializeField] private TrainSlot[] trainSlots;
        
        private TrainSlot selectedSlot;
        public override void OnInit()
        {
            
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
        }
    }
}
