namespace Zad_1_s30517;

 public class Kontenerowiec
    {
        public string Name { get; }
        private List<Kontener> kontenery = new List<Kontener>();
        private int maxContainers;
        private double maxWeight;
        private int maxSpeed;

        public Kontenerowiec(string name, int maxContainers, double maxWeight, int maxSpeed)
        {
            Name = name;
            this.maxContainers = maxContainers;
            this.maxWeight = maxWeight;
            this.maxSpeed = maxSpeed;
        }

        public void LoadContainer(Kontener kontener)
        {
            if (kontenery.Count >= maxContainers)
            {
                Console.WriteLine("Nie można dodać więcej kontenerów na statek " + Name + " - przekroczono limit.");
                return;
            }

            double totalWeight = TotalWeight() + kontener.getMassTogether();
            if (totalWeight > maxWeight)
            {
                Console.WriteLine("Przekroczono maksymalną wagę dla statku " + Name + ".");
                return;
            }

            kontenery.Add(kontener);
            Console.WriteLine("Dodano kontener " + kontener.serialNumber + " na statek " + Name + ".");
        }

        public void RemoveContainer(string serialNumber)
        {
            var kontener = kontenery.Find(k => k.serialNumber== serialNumber);
            if (kontener != null)
            {
                kontenery.Remove(kontener);
                Console.WriteLine("Usunięto kontener " + serialNumber + " ze statku " + Name + ".");
            }
            else
            {
                Console.WriteLine("Nie znaleziono kontenera " + serialNumber + " na statku " + Name + ".");
            }
        }

        public void TransferContainer(Kontenerowiec targetShip, string serialNumber)
        {
            var kontener = kontenery.Find(k => k.serialNumber == serialNumber);
            if (kontener == null)
            {
                Console.WriteLine("Nie znaleziono kontenera " + serialNumber + " na statku " + Name + ".");
                return;
            }

            RemoveContainer(serialNumber);
            targetShip.LoadContainer(kontener);
        }

        public double TotalWeight()
        {
            double totalWeight = 0;
            foreach (var kontener in kontenery)
                totalWeight += kontener.getMassTogether();
            return totalWeight;
        }

        public void ListContainers()
        {
            Console.WriteLine("Lista kontenerów na statku " + Name + ":");
            foreach (var kontener in kontenery)
                Console.WriteLine("- " + kontener.getSerialNumber());
        }
    }