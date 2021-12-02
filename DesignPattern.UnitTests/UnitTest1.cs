using DesignPattern.AbstractFactoryPattern;
using DesignPattern.AdapterPattern;
using DesignPattern.Bridge;
using DesignPattern.BuilderPattern;
using DesignPattern.ChainPattern;
using DesignPattern.CommandPattern;
using DesignPattern.CompositePattern;
using DesignPattern.DecoratorPattern;
using DesignPattern.FacadePattern;
using DesignPattern.FilterPattern;
using DesignPattern.InterpreterPattern;
using DesignPattern.IteratorPattern;
using DesignPattern.MediatorPattern;
using DesignPattern.MenmetoPattern;
using DesignPattern.ObserverPattern;
using DesignPattern.PrototypePattern;
using DesignPattern.ProxyPattern;
using DesignPattern.SingletonPattern;
using DesignPattern.StatePattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Circle = DesignPattern.Bridge.Circle;
using IShape = DesignPattern.DecoratorPattern.IShape;

namespace DesignPattern.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// 测试抽象工厂模式
        /// </summary>
        [TestMethod]
        public void AbstractFactoryPatternTest()
        {
            //获取形状工厂
            AbstractFactory shapeFactory = FactoryProducer.GetFactory("Shape");

            //获取形状为 Circle 的对象
            AbstractFactoryPattern.IShape shape1 = shapeFactory.GetShape("CIRCLE");

            //调用 Circle 的 Draw 方法
            shape1.Draw();

            //获取形状为 Rectangle 的对象
            AbstractFactoryPattern.IShape shape2 = shapeFactory.GetShape("RECTANGLE");

            //调用 Rectangle 的 Draw 方法
            shape2.Draw();

            //获取形状为 Square 的对象
            AbstractFactoryPattern.IShape shape3 = shapeFactory.GetShape("SQUARE");

            //调用 Square 的 Draw 方法
            shape3.Draw();

            //获取颜色工厂
            AbstractFactory colorFactory = FactoryProducer.GetFactory("Color");

            //获取颜色为 Red 的对象
            IColor color1 = colorFactory.GetColor("RED");

            //调用 Red 的 Fill 方法
            color1.Fill();

            //获取颜色为 Green 的对象
            IColor color2 = colorFactory.GetColor("Green");

            //调用 Green 的 Fill 方法
            color2.Fill();

            //获取颜色为 Blue 的对象
            IColor color3 = colorFactory.GetColor("BLUE");

            //调用 Blue 的 Fill 方法
            color3.Fill();
        }

        /// <summary>
        /// 适配器模式测试
        /// </summary>
        [TestMethod]
        public void AdaperPatternTest()
        {
            AudioPlayer audioPlayer = new AudioPlayer();
            audioPlayer.Play("mp3", "beyond the horizon.mp3");
            audioPlayer.Play("mp4", "alone.mp4");
            audioPlayer.Play("vlc", "far far away.vlc");
            audioPlayer.Play("avi", "mind me.avi");
        }

        /// <summary>
        /// 桥接模式测试
        /// </summary>
        [TestMethod]
        public void BridgePatternTest()
        {
            Bridge.Shape redCircle = new Circle(100, 100, 10, new RedCircle());
            Bridge.Shape greenCircle = new Circle(100, 100, 10, new GreenCircle());

            redCircle.Draw();
            greenCircle.Draw();
        }

        /// <summary>
        /// 测试建造者模式
        /// </summary>
        [TestMethod]
        public void BuilderPatternTest()
        {
            MealBuilder mealBuilder = new MealBuilder();

            Meal vegMeal = mealBuilder.PrepareVegMeal();
            Console.WriteLine("Veg Meal");
            vegMeal.ShowItems();
            Console.WriteLine("Total Cost: " + vegMeal.GetCost());

            Meal nonVegMeal = mealBuilder.PrepareNonVegMeal();
            Console.WriteLine("\n\nNon-Veg Meal");
            nonVegMeal.ShowItems();
            Console.WriteLine("Total Cost: " + nonVegMeal.GetCost());
        }

        /// <summary>
        /// 责任链模式测试
        /// </summary>
        [TestMethod]
        public void ChainPatternTest()
        {
            AbstractLogger loggerChain = getChainOfLoggers();

            loggerChain.LogMessage(AbstractLogger.INFO, "This is an information.");

            loggerChain.LogMessage(AbstractLogger.DEBUG,
               "This is a debug level information.");

            loggerChain.LogMessage(AbstractLogger.ERROR,
               "This is an error information.");
        }

        private static AbstractLogger getChainOfLoggers()
        {

            AbstractLogger errorLogger = new ErrorLogger(AbstractLogger.ERROR);
            AbstractLogger fileLogger = new FileLogger(AbstractLogger.DEBUG);
            AbstractLogger consoleLogger = new ConsoleLogger(AbstractLogger.INFO);

            errorLogger.SetNextLogger(fileLogger);
            fileLogger.SetNextLogger(consoleLogger);

            return errorLogger;
        }

        /// <summary>
        /// 命令模式测试
        /// </summary>
        [TestMethod]
        public void CommandPattern()
        {
            Stock abcStock = new Stock();

            BuyStock buyStockOrder = new BuyStock(abcStock);
            SellStock sellStockOrder = new SellStock(abcStock);

            Broker broker = new Broker();
            broker.TakeOrder(buyStockOrder);
            broker.TakeOrder(sellStockOrder);

            broker.PlaceOrders();
        }

        /// <summary>
        /// 组合模式
        /// </summary>
        [TestMethod]
        public void CompositePatternTest()
        {//CEO
            Employee CEO = new Employee("John", "CEO", 30000);
            //销售部主管
            Employee headSales = new Employee("Robert", "Head Sales", 20000);
            //市场部主管
            Employee headMarketing = new Employee("Michel", "Head Marketing", 20000);
            //促销员
            Employee clerk1 = new Employee("Laura", "Marketing", 10000);
            Employee clerk2 = new Employee("Bob", "Marketing", 10000);
            //销售员
            Employee salesExecutive1 = new Employee("Richard", "Sales", 10000);
            Employee salesExecutive2 = new Employee("Rob", "Sales", 10000);

            CEO.Add(headSales);
            CEO.Add(headMarketing);

            headSales.Add(salesExecutive1);
            headSales.Add(salesExecutive2);

            headMarketing.Add(clerk1);
            headMarketing.Add(clerk2);

            //打印该组织的所有员工
            Console.WriteLine(CEO);
            foreach (Employee headEmployee in CEO.GetSubordinates())
            {
                Console.WriteLine(headEmployee);
                foreach (Employee employee in headEmployee.GetSubordinates())
                {
                    Console.WriteLine(employee);
                }
            }
        }


        /// <summary>
        /// 装饰器模式测试
        /// </summary>
        [TestMethod]
        public void DecoratorPatternTest()
        {
            IShape circle = new DecoratorPattern.Circle();
            ShapeDecorator redCircle = new RedShapeDecorator(new DecoratorPattern.Circle());
            ShapeDecorator redRectangle = new RedShapeDecorator(new DecoratorPattern.Rectangle());
            Console.WriteLine("Circle with normal border");
            circle.Draw();

            Console.WriteLine("\nCircle of red border");
            redCircle.Draw();

            Console.WriteLine("\nRectangle of red border");
            redRectangle.Draw();
        }

        /// <summary>
        /// 外观模式测试
        /// </summary>
        [TestMethod]
        public void FacadePatternTest()
        {
            ShapeMaker shapeMaker = new ShapeMaker();

            shapeMaker.DrawCircle();
            shapeMaker.DrawRectangle();
            shapeMaker.DrawSquare();
        }

        /// <summary>
        /// 测试工厂模式
        /// </summary>
        [TestMethod]
        public void FactoryPatternTest()
        {
            FactoryPattern.ShapeFactory factory = new FactoryPattern.ShapeFactory();
            FactoryPattern.IShape circle = factory.GetShape("Circle");
            circle.Draw();
            FactoryPattern.IShape square = factory.GetShape("Square");
            square.Draw();
            FactoryPattern.IShape rectangle = factory.GetShape("Rectangle");
            rectangle.Draw();
        }

        /// <summary>
        /// 过滤器模式
        /// </summary>
        [TestMethod]
        public void FilterPatternTest()
        {
            List<Person> persons = new List<Person>();

            persons.Add(new Person("Robert", "Male", "Single"));
            persons.Add(new Person("John", "Male", "Married"));
            persons.Add(new Person("Laura", "Female", "Married"));
            persons.Add(new Person("Diana", "Female", "Single"));
            persons.Add(new Person("Mike", "Male", "Single"));
            persons.Add(new Person("Bobby", "Male", "Single"));

            ICriteria male = new CriteriaMale();
            ICriteria female = new CriteriaFemale();
            ICriteria single = new CriteriaSingle();
            ICriteria singleMale = new AndCriteria(single, male);
            ICriteria singleOrFemale = new OrCriteria(single, female);
            Console.WriteLine("Males: ");
            PrintPersons(male.MeetCriteria(persons));

            Console.WriteLine("\nFemales: ");
            PrintPersons(female.MeetCriteria(persons));

            Console.WriteLine("\nSingle Males: ");
            PrintPersons(singleMale.MeetCriteria(persons));

            Console.WriteLine("\nSingle Or Females: ");
            PrintPersons(singleOrFemale.MeetCriteria(persons));
        }

        public static void PrintPersons(List<Person> persons)
        {
            foreach (Person person in persons)
            {
                Console.WriteLine("Person : [ Name : " + person.GetName()
                   + ", Gender : " + person.GetGender()
                   + ", Marital Status : " + person.GetMaritalStatus()
                   + " ]");
            }
        }

        private static string[] colors = { "Red", "Green", "Blue", "White", "Black" };
        /// <summary>
        /// 享元模式测试
        /// </summary>
        [TestMethod]
        public void FlyweightPatternTest()
        {
            for (int i = 0; i < 20; ++i)
            {
                FlyweightPattern.Circle circle =
                   (FlyweightPattern.Circle)FlyweightPattern.ShapeFactory.GetCircle(getRandomColor());
                circle.SetX(GetRandomX());
                circle.SetY(GetRandomY());
                circle.SetRadius(100);
                circle.Draw();
            }
        }
        private static string getRandomColor()
        {
            return colors[(int)(new Random().Next(4))];
        }
        private static int GetRandomX()
        {
            return (int)(new Random().Next(4) * 100);
        }
        private static int GetRandomY()
        {
            return (int)(new Random().Next(4) * 100);
        }

        /// <summary>
        /// 解释器测试
        /// </summary>
        [TestMethod]
        public void InterpreterPatternTest()
        {
            IExpression isMale = GetMaleExpression();
            IExpression isMarriedWoman = GetMarriedWomanExpression();

            Console.WriteLine("John is male? " + isMale.Interpret("John"));
            Console.WriteLine("Julie is a married women? "
            + isMarriedWoman.Interpret("Married Julie"));
        }

        //规则：Robert 和 John 是男性
        public static IExpression GetMaleExpression()
        {
            IExpression robert = new TerminalExpression("Robert");
            IExpression john = new TerminalExpression("John");
            return new OrExpression(robert, john);
        }

        //规则：Julie 是一个已婚的女性
        public static IExpression GetMarriedWomanExpression()
        {
            IExpression julie = new TerminalExpression("Julie");
            IExpression married = new TerminalExpression("Married");
            return new AndExpression(julie, married);
        }

        /// <summary>
        /// 迭代器模式测试
        /// </summary>
        [TestMethod]
        public void IteratorPatternTest()
        {
            NameRepository namesRepository = new NameRepository();

            for (IIterator iter = namesRepository.GetIterator(); iter.HasNext();)
            {
                string name = (string)iter.Next();
                Console.WriteLine("Name : " + name);
            }
        }

        /// <summary>
        /// 备忘录模式
        /// </summary>
        [TestMethod]
        public void MenmotoPatternTests()
        {
            Originator originator = new Originator();
            CareTaker careTaker = new CareTaker();
            originator.SetState("State #1");
            originator.SetState("State #2");
            careTaker.Add(originator.SaveStateToMemento());
            originator.SetState("State #3");
            careTaker.Add(originator.SaveStateToMemento());
            originator.SetState("State #4");

            Console.WriteLine("Current State: " + originator.GetState());
            originator.GetStateFromMemento(careTaker.Get(0));
            Console.WriteLine("First saved State: " + originator.GetState());
            originator.GetStateFromMemento(careTaker.Get(1));
            Console.WriteLine("Second saved State: " + originator.GetState());
        }

        /// <summary>
        /// 原型模式测试
        /// </summary>
        [TestMethod]
        public void PrototypePatternTest()
        {
            ShapeCache.LoadCache();

            PrototypePattern.Shape clonedShape = (PrototypePattern.Shape)ShapeCache.GetShape("1");
            Console.WriteLine("Shape : " + clonedShape.GetType());

            PrototypePattern.Shape clonedShape2 = (PrototypePattern.Shape)ShapeCache.GetShape("2");
            Console.WriteLine("Shape : " + clonedShape2.GetType());

            PrototypePattern.Shape clonedShape3 = (PrototypePattern.Shape)ShapeCache.GetShape("3");
            Console.WriteLine("Shape : " + clonedShape3.GetType());
        }

        class Emp
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        /// <summary>
        /// 代理模式测试
        /// </summary>
        [TestMethod]
        public void ProxyPatternTest()
        {
            IImage image = new ProxyImage("test_10mb.jpg");
            // 图像将从磁盘加载
            image.Display();
            Console.WriteLine("");
            // 图像不需要从磁盘加载
            image.Display();
        }

        /// <summary>
        /// 单例模式测试
        /// </summary>
        [TestMethod]
        public void SingletonPatternTest()
        {
            //不合法的构造函数
            //编译时错误：构造函数 SingleObject() 是不可见的
            //SingleObject obj = new SingleObject();

            //获取唯一可用的对象
            SingleObject obj = SingleObject.GetInstance();

            //显示消息
            obj.ShowMessage();
        }

        /// <summary>
        /// 中介者模式
        /// </summary>
        [TestMethod]
        public void MediatorPatternTests()
        {
            User robert = new User("Robert");
            User john = new User("John");

            robert.SendMessage("Hi! John!");
            john.SendMessage("Hello! Robert!");
        }

        /// <summary>
        /// 观察者模式测试
        /// </summary>
        [TestMethod]
        public void ObserverPatternTest()
        {
            Subject subject = new Subject();

            new HexaObserver(subject);
            new OctalObserver(subject);
            new BinaryObserver(subject);

            Console.WriteLine("First state change: 15");
            subject.SetState(15);
            Console.WriteLine("Second state change: 10");
            subject.SetState(10);
        }

        /// <summary>
        /// 状态模式测试
        /// </summary>
        [TestMethod]
        public void StatePatternTest()
        {
            Context context = new Context();

            StartState startState = new StartState();
            startState.DoAction(context);

            Console.WriteLine(context.GetState().ToString());

            StopState stopState = new StopState();
            stopState.DoAction(context);

            Console.WriteLine(context.GetState().ToString());
        }
    }
}
