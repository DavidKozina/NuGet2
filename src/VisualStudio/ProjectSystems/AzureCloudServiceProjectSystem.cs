﻿using System;
using EnvDTE;

namespace NuGet.VisualStudio
{
    public class AzureCloudServiceProjectSystem : VsProjectSystem
    {
       public AzureCloudServiceProjectSystem( Project project, IFileSystemProvider fileSystemProvider )
            : base(project, fileSystemProvider)
        {
        }

        private const string RootNamespace = "RootNamespace";
        private const string OutputName = "OutputName";
        private const string DefaultNamespace = "Azure";

        public override bool IsBindingRedirectSupported
        {
            get
            {
                // Binding redirect just doesn't make sense in Azure project
                return false;
            }
        }

        public override void AddReference(string referencePath, System.IO.Stream stream)
        {
            // References aren't allowed for Azure projects
        }

        protected override void AddFileToContainer( string fullPath, ProjectItems container )
        {
           // You can't add files to an Azure project
        }

        public override void DeleteDirectory(string path, bool recursive = false)
        {
           // You can't remove a directory from an Azure project
        }

        public override void DeleteFile( string path )
        {
           // You can't remove files from an Azure project
        }

        public override void RemoveReference(string name)
        {
            // References aren't allowed for Azure projects
        }

        public override bool ReferenceExists(string name)
        {
            // References aren't allowed for Azure projects
            return true;
        }

        protected override void AddGacReference(string name)
        {
            // GAC references aren't allowed for Azure projects
        }

        public override bool IsSupportedFile(string path)
        {
            return true;
        }

        public override dynamic GetPropertyValue(string propertyName)
        {
            if (propertyName.Equals(RootNamespace, StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    return base.GetPropertyValue(OutputName);
                }
                catch
                {
                    return DefaultNamespace;
                }
            }
            return base.GetPropertyValue(propertyName);
        }

        protected override bool ExcludeFile(string path)
        {
            // Exclude nothing from Azure projects
            return false;
        }
    }
}