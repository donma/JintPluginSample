using System;

namespace JintDPlugin
{
    class Program
    {

        public class ReflactAgent{

            public string GetInfo(string file, string className) {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + file);


                foreach (var t in assembly.GetTypes())
                {

                    if (t.IsClass && t.Name == className)
                    {
                        var ins = (Activator.CreateInstance(t) as IDplugin);
                        return ins.Name + "," + ins.Version;
                    }
                }
                throw new EntryPointNotFoundException("I cant Find class.");
            }
            public string Run(string file,string className,string input) {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + file);

            
                foreach (var t in assembly.GetTypes())
                {

                    if (t.IsClass && t.Name == className)
                    {
                        return (Activator.CreateInstance(t) as IDplugin).CallResult(input);
                    }
                }
                throw new EntryPointNotFoundException("I cant Find class.");

            }

        }


        static void Main(string[] args)
        {


            var engine = new Jint.Engine();
            engine.SetValue("PLUGIN", new ReflactAgent());
            var jsCode = @"


                function Main(){

                    return PLUGIN.Run('DPlugin1.dll','MD5','當麻許測試');

                }

                function LibInfo(){
                    return PLUGIN.GetInfo('DPlugin1.dll','MD5');
                }

            ";
            engine.Execute(jsCode);

            var info = engine.Execute("LibInfo()").GetCompletionValue();
            Console.WriteLine(info);
            //MD5 Library,2022222
            

            var result = engine.Execute("Main()").GetCompletionValue();
            Console.WriteLine(result);
            //7e8b333efb930a36314bdcb364d3c6ea


        }
    }
}
