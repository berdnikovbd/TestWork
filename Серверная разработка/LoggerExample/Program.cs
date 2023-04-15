using LoggerExample.ClassesForTesting;
using LoggerExample.Controllers;
using LoggerExample.Models;
using LoggerExample.Services;
using LoggerExample.Utils.Loggers;
using LoggerExample.Views;

Startup();

CallControllers();

TestLogging();

void Startup()
{
    ConfigureLoggers.Configure();
}

void CallControllers()
{
    var sumIntNumberController = new SumIntNumberController();
    sumIntNumberController.Get(1, 2, new SumIntNumberService(), new DataService());
    sumIntNumberController.Get(int.MaxValue - 100, 1, new SumIntNumberService(), new DataService());

    var doubleDivisionController = new DoubleDivisionController();
    doubleDivisionController.Get(3.0, 2.0, new DoubleDivisionService(), new DataService());
    try
    {
        doubleDivisionController.Get(3.0, 0.0, new DoubleDivisionService(), new DataService());
    }
    catch (Exception ex)
    {
        Log.Exception<Program>(ex);
    }
}

void TestLogging()
{
    // Проверка методов.
    Log.Info<Program>("Со статусом Info");
    Log.Warn<Program>("Со статусом Warn");
    Log.Debug<Program>("Со статусом Debug. В релизной сборке нет.");
    
    // Проверка источников.
    Log.Info<Program>("источник unknown");
    Log.Info<DoubleDivisionService>("Источник обработчика данных.");
    // Проверка хождения по иерархии логгер-сервисов.
    // Здесь обработчик выше чем для сервсиов.
    Log.Info<DataService>("источник сервис БД. источника обработчика данных нет, т.к. он ниже по иерархии.");
    // Здесь нет обработчика, спускается до обработчика по умолчанию.
    Log.Info<DoubleNumberView>("источник unkown, т.к. нет слоя для view и ближайший по иерархии unkown");
    
    // Проверка сокрытия при уровне.
    Log.Info<IntNumber>("не отображается, т.к. для model's уровень - Error");
    Log.Error<IntNumber>(new Exception("источник слой данных, отображается"));

    // Проверка обратчиков ошибок от уровня.
    Log.Exception<SimpleErrorer>(new Exception("Пример обработчика с нефатальными ошибками. вызов через эксепшион. Должен быть статус еррор"));
    Log.Error<SimpleErrorer>(new Exception("Пример обработчика с нефатальными ошибками. вызов через error"));
    Log.Fatal<SimpleErrorer>(new Exception("Пример обработчика с нефатальными ошибками. вызов через fatal"));
    
    Log.Exception<FatalErrorer>(new Exception("Пример обработчика с фатальными ошибками. вызов через эксепшион. Должен быть статус фатал"));
    Log.Error<FatalErrorer>(new Exception("Пример обработчика с фатальными ошибками. вызов через error"));
    Log.Fatal<FatalErrorer>(new Exception("Пример обработчика с фатальными ошибками. вызов через fatal"));


    // Проверка уровней логгирования.
    Log.Info<AllLevel>("Вывожу все");
    Log.Debug<AllLevel>("Вывожу все");
    Log.Warn<AllLevel>("Вывожу все");
    Log.Error<AllLevel>(new Exception("Вывожу все"));
    Log.Fatal<AllLevel>(new Exception("Вывожу все"));

    Log.Info<DebugLevel>("Вывожу Debug и ниже");
    Log.Debug<DebugLevel>("Вывожу Debug и ниже");
    Log.Warn<DebugLevel>("Вывожу Debug и ниже");
    Log.Error<DebugLevel>(new Exception("Вывожу Debug и ниже"));
    Log.Fatal<DebugLevel>(new Exception("Вывожу Debug и ниже"));
    
    Log.Info<WarnLevel>("Вывожу Warn и ниже");
    Log.Debug<WarnLevel>("Вывожу Warn и ниже");
    Log.Warn<WarnLevel>("Вывожу Warn и ниже");
    Log.Error<WarnLevel>(new Exception("Вывожу Warn и ниже"));
    Log.Fatal<WarnLevel>(new Exception("Вывожу Warn и ниже"));

    Log.Info<ErrorLevel>("Вывожу Error и ниже");
    Log.Debug<ErrorLevel>("Вывожу Error и ниже");
    Log.Warn<ErrorLevel>("Вывожу Error и ниже");
    Log.Error<ErrorLevel>(new Exception("Вывожу Error и ниже"));
    Log.Fatal<ErrorLevel>(new Exception("Вывожу Error и ниже"));

    Log.Info<FatalLevel>("Вывожу Fatal и ниже");
    Log.Debug<FatalLevel>("Вывожу Fatal и ниже");
    Log.Warn<FatalLevel>("Вывожу Fatal и ниже");
    Log.Error<FatalLevel>(new Exception("Вывожу Fatal и ниже"));
    Log.Fatal<FatalLevel>(new Exception("Вывожу Fatal и ниже"));

    Log.Info<OffLevel>("Ничего не вывожу");
    Log.Debug<OffLevel>("Ничего не вывожу");
    Log.Warn<OffLevel>("Ничего не вывожу");
    Log.Error<OffLevel>(new Exception("Ничего не вывожу"));
    Log.Fatal<OffLevel>(new Exception("Ничего не вывожу"));

    Log.Info<Aggregated>("Вывожу и в nlog, и в консоль");
    Log.Debug<Aggregated>("Вывожу и в nlog, и в консоль");
    Log.Warn<Aggregated>("Вывожу и в nlog, и в консоль");
    Log.Error<Aggregated>(new Exception("Вывожу и в nlog, и в консоль"));
    Log.Fatal<Aggregated>(new Exception("Вывожу и в nlog, и в консоль"));

    Log.Info<ConsoleLogOnly>("Вывожу толлько в консоль");
    Log.Debug<ConsoleLogOnly>("Вывожу толлько в консоль");
    Log.Warn<ConsoleLogOnly>("Вывожу толлько в консоль");
    Log.Error<ConsoleLogOnly>(new Exception("Вывожу толлько в консоль"));
    Log.Fatal<ConsoleLogOnly>(new Exception("Вывожу толлько в консоль"));

    Log.Debug<Aggregated>("Меня нет в релизе в консоли, и в nlog");
}