using System;
using System.Configuration;

namespace ProvaCandidato
{
    public static class ProjectEnvironments
    {
        private static string GetVariable(string variable)
        {
            string varName = variable.ToString();

            string value = Environment.GetEnvironmentVariable(varName);

            if (!String.IsNullOrEmpty(value)) return value;

            return Environment.GetEnvironmentVariable(varName, EnvironmentVariableTarget.Machine);
        }

        public static string ENV_NOME_EMPRESA => GetVariable("NomeEmpresa");
    }
}