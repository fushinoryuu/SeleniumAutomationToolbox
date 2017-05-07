#tool "nuget:?package=NUnit.ConsoleRunner&version=3.6.1"

Task("NUnit")
    .Description("Runs the NUnit tests.")
    .IsDependentOn("CompileDebug")
    .Does(() =>
    {
        var testAssemblies = getTestAssemblies();

        NUnit3(testAssemblies, new NUnit3Settings
        {
            Workers = 30,
            Verbose = true,
            Work = "./Build"
        });
    });

private IEnumerable<FilePath> getTestAssemblies()
{
    var testAssemblies = GetFiles(Constants.TestAssembliesGlob);
    return testAssemblies;
}