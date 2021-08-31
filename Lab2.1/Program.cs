using System;
using System.Threading;

class SumArray
{
    int sum;
    object lockOn = new object();

    public int Sum(int[] nums) {
        lock (lockOn)
        {
            sum = 0;
            for(int i=0; i<nums.Length; i++)
            {
                sum += nums[i];
                Console.WriteLine("Теущая сумма для потока" + Thread.CurrentThread.Name + "равна" + sum);
                Thread.Sleep(10);            
            }
            return sum;
        }
    }

}

class MyThread
{
    public Thread Thrd;
    int[] a;
    int answer;
    static SumArray sa = new SumArray();

    public MyThread(string name, int[] nums)
    {
        a = nums;
        Thrd = new Thread(this.Run);
        Thrd.Name = name;
        Thrd.Start();
    }
        void Run()
        {
            Console.WriteLine(Thrd.Name + " начат");
            answer = sa.Sum(a);
            Console.WriteLine("Сумма для потока " + Thrd.Name +  " равна " + answer);
            Console.WriteLine(Thrd.Name +  " завершен ");
        }
    
}

namespace Lab2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 3, 4, 5 };
            MyThread MT1 = new MyThread(" Поток 1 ", a);
            MyThread MT2 = new MyThread(" Поток 2 ", a);
        }
    }
}
