using CreateBuildDefinitionAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateBuildDefinitionAPI.Create
{
    public class Task
    {
        public string id { get; set; }
        public string versionSpec { get; set; }
    }

    public class Inputs
    {
        public string solution { get; set; }
        public string nugetConfigPath { get; set; }
        public string noCache { get; set; }
        public string nuGetRestoreArgs { get; set; }
        public string nuGetPath { get; set; }
        public string msbuildArgs { get; set; }
        public string platform { get; set; }
        public string configuration { get; set; }
        public string clean { get; set; }
        public string restoreNugetPackages { get; set; }
        public string vsVersion { get; set; }
        public string msbuildArchitecture { get; set; }
        public string logProjectEvents { get; set; }
        public string testAssembly { get; set; }
        public string testFiltercriteria { get; set; }
        public string runSettingsFile { get; set; }
        public string overrideTestrunParameters { get; set; }
        public string codeCoverageEnabled { get; set; }
        public string runInParallel { get; set; }
        public string vsTestVersion { get; set; }
        public string pathtoCustomTestAdapters { get; set; }
        public string otherConsoleOptions { get; set; }
        public string testRunTitle { get; set; }
        public string publishRunAttachments { get; set; }
        public string SymbolsPath { get; set; }
        public string SearchPattern { get; set; }
        public string SymbolsFolder { get; set; }
        public string SkipIndexing { get; set; }
        public string TreatNotIndexedAsWarning { get; set; }
        public string SymbolsMaximumWaitTime { get; set; }
        public string SymbolsProduct { get; set; }
        public string SymbolsVersion { get; set; }
        public string SymbolsArtifactName { get; set; }
        public string SourceFolder { get; set; }
        public string Contents { get; set; }
        public string TargetFolder { get; set; }
        public string CleanTargetFolder { get; set; }
        public string OverWrite { get; set; }
        public string PathtoPublish { get; set; }
        public string ArtifactName { get; set; }
        public string ArtifactType { get; set; }
        public string TargetPath { get; set; }
    }

    public class Build
    {
        public bool enabled { get; set; }
        public bool continueOnError { get; set; }
        public bool alwaysRun { get; set; }
        public string displayName { get; set; }
        public Task task { get; set; }
        public Inputs inputs { get; set; }
    }

    public class Definition
    {
        public string id { get; set; }
    }

    public class Inputs2
    {
        public string multipliers { get; set; }
        public string parallel { get; set; }
        public string continueOnError { get; set; }
        public string additionalFields { get; set; }
        public string workItemType { get; set; }
        public string assignToRequestor { get; set; }
    }

    public class Option
    {
        public bool enabled { get; set; }
        public Definition definition { get; set; }
        public Inputs2 inputs { get; set; }
    }

    public class SystemDebug
    {
        public string value { get; set; }
        public bool allowOverride { get; set; }
    }

    public class BuildConfiguration
    {
        public string value { get; set; }
        public bool allowOverride { get; set; }
    }

    public class BuildPlatform
    {
        public string value { get; set; }
        public bool allowOverride { get; set; }
    }

    public class Variables
    {
        public BuildConfiguration BuildConfiguration { get; set; }
        public BuildPlatform BuildPlatform { get; set; }
    }

    public class RetentionRule
    {
        public List<string> branches { get; set; }
        public List<string> artifacts { get; set; }
        public int daysToKeep { get; set; }
        public int minimumToKeep { get; set; }
        public bool deleteBuildRecord { get; set; }
        public bool deleteTestResults { get; set; }
    }

    public class Self
    {
        public string href { get; set; }
    }

    public class Web
    {
        public string href { get; set; }
    }

    public class Links
    {
        public Self self { get; set; }
        public Web web { get; set; }
    }

    public class Properties
    {
        public string labelSources { get; set; }
    }

    public class Repository
    {
        public Properties properties { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string defaultBranch { get; set; }
        public string clean { get; set; }
        public bool checkoutSubmodules { get; set; }
        public string rootFolder { get; set; }
    }

    public class AuthoredBy
    {
        public string id { get; set; }
        public string displayName { get; set; }
        public string uniqueName { get; set; }
        public string url { get; set; }
        public string imageUrl { get; set; }
    }

    public class Pool
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Queue
    {
        public Pool pool { get; set; }
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Project
    {
        public string id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string state { get; set; }
        public int revision { get; set; }
    }

    public class BuildDefinitionCreate
    {
        public List<Build> build { get; set; }
        public List<Option> options { get; set; }
        public Variables variables { get; set; }
        public List<RetentionRule> retentionRules { get; set; }
        public Links _links { get; set; }
        public string buildNumberFormat { get; set; }
        public string jobAuthorizationScope { get; set; }
        public int jobTimeoutInMinutes { get; set; }
        public Repository repository { get; set; }
        public string quality { get; set; }
        public AuthoredBy authoredBy { get; set; }
        public Queue queue { get; set; }
        public string uri { get; set; }
        public string type { get; set; }
        public int revision { get; set; }
        public string createdDate { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public Project project { get; set; }
    }
}