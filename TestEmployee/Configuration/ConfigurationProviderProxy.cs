using Autofac;
using AutoMapper;
using System;
using System.Linq.Expressions;

namespace Web_API.Configuration
{
    //https://www.paraesthesia.com/archive/2014/03/25/automapper-autofac-web-api-and-per-request-dependency-lifetime-scopes.aspx/
    public class ConfigurationProviderProxy //: IConfigurationProvider
    {
        //private IComponentContext _context;
        //private IConfigurationProvider _provider;

        // Take in a configuration provider we're going to wrap
        // and an Autofac context from which we can resolve things.
        //public ConfigurationProviderProxy(IConfigurationProvider provider, IComponentContext context)
        //{
        //    _provider = provider;
        //    _context = context;
        //}

        // This is the important bit - we use the passed-in
        // Autofac context to resolve dependencies.
        //public Func<Type, object> ServiceCtor
        //{
        //    get
        //    {
        //        return _context.Resolve;
        //    }
        //}

        //
        // EVERYTHING ELSE IN THE CLASS IS JUST WRAPPER/PROXY
        // CODE TO PASS THROUGH TO THE BASE PROVIDER.
        //
        // public bool MapNullSourceCollectionsAsNull { get { return this._provider.MapNullSourceCollectionsAsNull; } }

        // public bool MapNullSourceValuesAsNull { get { return this._provider.MapNullSourceValuesAsNull; } }

        //public event EventHandler<TypeMapCreatedEventArgs> TypeMapCreated
        //{
        //    add { this._provider.TypeMapCreated += value; }
        //    remove { this._provider.TypeMapCreated -= value; }
        //}       

        //public void AssertConfigurationIsValid()
        //{
        //    _provider.AssertConfigurationIsValid();
        //}

        //public void AssertConfigurationIsValid(TypeMap typeMap)
        //{
        //    this._provider.AssertConfigurationIsValid(typeMap);
        //}

        //public void AssertConfigurationIsValid(string profileName)
        //{
        //    this._provider.AssertConfigurationIsValid(profileName);
        //}

        //public LambdaExpression BuildExecutionPlan(Type sourceType, Type destinationType)
        //{
        //    var res = _provider.CreateMapper();
        //    return 

        //}

        //public TypeMap CreateTypeMap(Type sourceType, Type destinationType)
        //{
        //    return this._provider.CreateTypeMap(sourceType, destinationType);
        //}
      

        //public TypeMap FindTypeMapFor(ResolutionResult resolutionResult, Type destinationType)
        //{
        //    return this._provider.FindTypeMapFor(resolutionResult, destinationType);
        //}

        //public TypeMap FindTypeMapFor(Type sourceType, Type destinationType)
        //{
        //    return this._provider.FindTypeMapFor(sourceType, destinationType);
        //}

        //public TypeMap FindTypeMapFor(object source, object destination, Type sourceType, Type destinationType)
        //{
        //    return this._provider.FindTypeMapFor(source, destination, sourceType, destinationType);
        //}

        //public TypeMap[] GetAllTypeMaps()
        //{
        //    return this._provider.GetAllTypeMaps();
        //}

        //public IObjectMapper[] GetMappers()
        //{
        //    return this._provider.GetMappers();
        //}

        //public IFormatterConfiguration GetProfileConfiguration(string profileName)
        //{
        //    return this._provider.GetProfileConfiguration(profileName);
        //}

    }
}
