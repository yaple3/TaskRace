﻿using System.Diagnostics;

using TaskRace;

namespace TaskRace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Read, Set Go...");
            Console.WriteLine();
            int t1Location = 0;
            int t2Location = 0;
            int t3Location = 0;
            int t4Location = 0;
            int t5Location = 0;

            //Creating Tasks
            Task t1 = Task.Run(() =>
            {
                Thread.CurrentThread.Name = "Speedy Gonzales";
                for (int i = 0; i < 100; i++)
                {
                    if (t1Location < 100 && t2Location < 100 && t3Location < 100 && t4Location < 100 && t5Location < 100)
                        MoveIt(ref t1Location);
                }
                //Setting the priority of the thread
                Thread.CurrentThread.Priority = ThreadPriority.AboveNormal;

            });
            Task t2 = Task.Run(() =>
            {
                Thread.CurrentThread.Name = "Road Runner";
                for (int i = 0; i < 100; i++)
                {
                    if (t1Location < 100 && t2Location < 100 && t3Location < 100 && t4Location < 100 && t5Location < 100)
                        MoveIt(ref t2Location);

                }
            });

            Task t3 = Task.Run(() =>
            {
                Thread.CurrentThread.Name = "Bugs Bunny";
                for (int i = 0; i < 100; i++)
                {
                    if (t1Location < 100 && t2Location < 100 && t3Location < 100 && t4Location < 100 && t5Location < 100)
                        MoveIt(ref t3Location);
                }

            });

            Task t4 = Task.Run(() =>
            {
                Thread.CurrentThread.Name = "Daffy Duck";
                for (int i = 0; i < 100; i++)
                {
                    if (t1Location < 100 && t2Location < 100 && t3Location < 100 && t4Location < 100 && t5Location < 100)
                        MoveIt(ref t4Location);

                }
            });

            Task t5 = Task.Run(() =>
            {
                Thread.CurrentThread.Name = "Porky Pig";
                for (int i = 0; i < 100; i++)
                {
                    if (t1Location < 100 && t2Location < 100 && t3Location < 100 && t4Location < 100 && t5Location < 100)
                        MoveIt(ref t5Location);
                }

            });


            Task.WaitAny(t1, t2, t3, t4, t5);
            Console.WriteLine("<<<<<<<<<  Race has ended  >>>>>>>>>");
        }
        static void MoveIt(ref int location)
        {
            location++;
            Console.WriteLine($"{Thread.CurrentThread.Name} location={location}");
            if (location >= 100)
            {
                Console.WriteLine($"*********  {Thread.CurrentThread.Name} is the winner  *********");
                return;
            }
        }

    }
}