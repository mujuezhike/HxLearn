using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HxLearn.Lab
{
    class DomainTest
    {
        public static void Marshalling()
        {
            AppDomain nowDomain = Thread.GetDomain();
            String nowDomainName = nowDomain.FriendlyName;
            Console.WriteLine(nowDomainName);

            String exeAssembly = Assembly.GetEntryAssembly().FullName;
            Console.WriteLine(exeAssembly);

            AppDomain ad2 = null;
            ad2 = AppDomain.CreateDomain("AD #2", null, null);
            MarshalByRefType mbrt = null;
            mbrt = (MarshalByRefType)ad2.CreateInstanceAndUnwrap(exeAssembly, "HxLearn.Lab.MarshalByRefType");

            Console.WriteLine("Type: {0}", mbrt.GetType());

            //看是否是代理对象
            Console.WriteLine("Is proxy={0}",RemotingServices.IsTransparentProxy(mbrt));
            mbrt.SomeMethod();
            AppDomain.Unload(ad2);
            try { 
                mbrt.SomeMethod();
            }catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            ad2 = AppDomain.CreateDomain("AD #2", null, null);
            mbrt = (MarshalByRefType)ad2.CreateInstanceAndUnwrap(exeAssembly, "HxLearn.Lab.MarshalByRefType");
            MarshalByValueType mbvt = mbrt.MethodWithReturn();
            Console.WriteLine("Is proxy={0}", RemotingServices.IsTransparentProxy(mbvt));
            Console.WriteLine("Return object created", mbvt.ToString());

            AppDomain.Unload(ad2);
            try
            {
                mbvt.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            ad2 = AppDomain.CreateDomain("AD #2", null, null);
            mbrt = (MarshalByRefType)ad2.CreateInstanceAndUnwrap(exeAssembly, "HxLearn.Lab.MarshalByRefType");
            NonMarshalableType nmt = mbrt.MethodArgsAndReturn(nowDomainName);

        }


    }

    public sealed class MarshalByRefType : MarshalByRefObject
    {
        public MarshalByRefType()
        {
            Console.WriteLine("{0} actor running in {1}",
                this.GetType().ToString(), Thread.GetDomain().FriendlyName);
        }

        public void SomeMethod()
        {
            Console.WriteLine("SomeMethod executed in {0}",
               Thread.GetDomain().FriendlyName);
        }

        public MarshalByValueType MethodWithReturn()
        {
            Console.WriteLine("MethodWithReturn executed in {0}",
              Thread.GetDomain().FriendlyName);
            MarshalByValueType mr = new MarshalByValueType();
            return mr;
        }

        public NonMarshalableType MethodArgsAndReturn(string theDomain)
        {
            Console.WriteLine("Call from {0} to {1}",
              theDomain, Thread.GetDomain().FriendlyName);
            NonMarshalableType nt = new NonMarshalableType();
            return nt;
        }
    }

    [Serializable]
    public sealed class MarshalByValueType : Object
    {
        private DateTime dt = DateTime.Now;

        public MarshalByValueType()
        {
            Console.WriteLine("{0} actor running in {1}, create on {2}",
                this.GetType().ToString()
                , Thread.GetDomain().FriendlyName
                , dt);
        }

        public override string ToString()
        {
            return base.ToString() + "|" + dt;
        }

    }

    //[Serializable]
    public sealed class NonMarshalableType : Object
    {
        public NonMarshalableType()
        {
            Console.WriteLine("{0} actor running in {1}",
                this.GetType().ToString()
                , Thread.GetDomain().FriendlyName);
        }
    }
}
