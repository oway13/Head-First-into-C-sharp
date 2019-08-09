using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveManagerCh6
{
    class Queen : Bee
    {
        public Queen(Worker[] workers) :base(275)
        {
            this.workers = workers;
        }

        private Worker[] workers;
        private int shiftNumber = 0;

        public bool AssignWork(string job, int numberOfShifts)
        {
            for (int i = 0; i < workers.Length; i++)
            {
                if (workers[i].DoThisJob(job, numberOfShifts))
                    return true;
            }
            return false;
        }

        public string WorkTheNextShift()
        {
            shiftNumber++;
            string report = "Report for shift #" + shiftNumber + "\r\n";
            double totalHoney = 0;
            for(int i = 0; i < workers.Length; i++)
            {
                totalHoney += workers[i].GetHoneyConsumption();
            }
            totalHoney += this.GetHoneyConsumption();
            report += "Total Honey Consumption: " + totalHoney + " units\r\n";
            for (int i = 0; i < workers.Length; i++)
            {
                if (workers[i].WorkOneShift())
                {
                    report += "Worker #" + (i + 1) + " finished the job \r\n";
                }
                if (String.IsNullOrEmpty(workers[i].CurrentJob))
                {
                    report += "Worker #" + (i + 1) + " is not working\r\n";
                }
                else
                {
                    if (workers[i].ShiftsLeft > 0)
                    {
                        report += "Worker #" + (i + 1) + " is doing '" + workers[i].CurrentJob + "' for " + workers[i].ShiftsLeft + " more shifts\r\n";
                    }
                    else
                    {
                        report += "Worker #" + (i + 1) + " will be done with '" + workers[i].CurrentJob + "' after this shift \r\n";
                    }
                }
                
            }
            return report;
        }

        public override double GetHoneyConsumption()
        {
            double honey = 0;
            int workingCount = 0;
            double mostShifts = 0;
            for (int i = 0; i < workers.Length; i++)
            {
                if (!string.IsNullOrEmpty(workers[i].CurrentJob))
                    workingCount++;
                if (workers[i].ShiftsLeft > mostShifts)
                    mostShifts = workers[i].ShiftsLeft;
            }
            if (workingCount > 2)
                honey += 30;
            else
                honey += 20;
            return honey + 9 + mostShifts;
        }
    }
}
