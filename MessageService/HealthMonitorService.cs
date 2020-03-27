using System;
using System.Timers;

namespace MessageService
{
    internal class HealthMonitorService
    {
        private readonly Timer _timer;
        private readonly Timer _timer1;
        private readonly Timer _timer2;
        public HealthMonitorService()
        {

            _timer = new Timer(1000*60*60*2) { AutoReset = true };
            _timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);


            _timer1 = new Timer(1000*60*60*3) { AutoReset = true };
            _timer1.Elapsed += new ElapsedEventHandler(OnTimedEvent1);

            _timer2= new Timer(1000*60*60*1) { AutoReset = true };
            _timer2.Elapsed += new ElapsedEventHandler(OnTimedEvent2);
        }

        public void Start()
        {
            _timer.Start();
            _timer1.Start();
            _timer2.Start();
           
        }
        public void Stop()
        {
            _timer.Stop();
            _timer1.Stop();
            _timer2.Stop();
        }

        //指定Timer触发的事件
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Advance触发的事件发生在：{0}", e.SignalTime);
            new BillboardsRentIncomeJob().Execute();
        }


        //指定Timer触发的事件
        private static void OnTimedEvent1(object source, ElapsedEventArgs e)
        {
            Console.WriteLine(" 房屋租金到期提醒HouseIncome触发的事件发生在： {0}", e.SignalTime);
            new HouseRentIncomeJob().Execute();
        }

        //指定Timer触发的事件
        private static void OnTimedEvent2(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("督办工作提醒OSNotice触发的事件发生在： {0}", e.SignalTime);
            new OverWorkJob().Execute();
        }
    }
}
