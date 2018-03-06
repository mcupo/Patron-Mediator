using System;

namespace DoFactory.GangOfFour.Mediator.Structural

{

    class MainApp

    {

        static void Main()

        {

            ConcreteMediator m = new ConcreteMediator();

            ConcreteColleague1 c1 = new ConcreteColleague1(m);

            ConcreteColleague2 c2 = new ConcreteColleague2(m);

            m.Colleague1 = c1;

            m.Colleague2 = c2;

            c1.Send("¿Como estas?");

            c2.Send("Bien, gracias");

            Console.ReadKey();

        }

    }

    //La clase abstracta Mediador que no siempre es necesaria

    abstract class Mediator

    {

        public abstract void Send(string message,Colleague colleague);

    }

    //La clase MediadorConcreto

    class ConcreteMediator : Mediator

    {

        private ConcreteColleague1 _colleague1;

        private ConcreteColleague2 _colleague2;

        public ConcreteColleague1 Colleague1

        {

            set { _colleague1 = value; }

        }

        public ConcreteColleague2 Colleague2

        {

            set { _colleague2 = value; }

        }

        public override void Send(string message,Colleague colleague)

        {

            if (colleague == _colleague1)

            {

                _colleague2.Notify(message);

            }

            else

            {

                _colleague1.Notify(message);

            }

        }

    }

    //La clase abstracta Colega

    abstract class Colleague

    {

        protected Mediator mediator;

        public Colleague(Mediator mediator)

        {

            this.mediator = mediator;

        }

    }

    //La clase ColegaConcreto1

    class ConcreteColleague1 : Colleague

    {

        public ConcreteColleague1(Mediator mediator) : base(mediator){}

        public void Send(string message)

        {

            mediator.Send(message, this);

        }

        public void Notify(string message)

        {

            Console.WriteLine("Colleague1 gets message: " + message);

        }

    }

    //La clase ColegaConcreto2

    class ConcreteColleague2 : Colleague

    {

        public ConcreteColleague2(Mediator mediator) : base(mediator){}

        public void Send(string message)

        {

            mediator.Send(message, this);

        }

        public void Notify(string message)

        {

            Console.WriteLine("Colleague2 gets message: " + message);

        }

    }

}
