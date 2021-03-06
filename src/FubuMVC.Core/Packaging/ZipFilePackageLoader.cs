using System.Collections.Generic;
using System.Linq;
using Bottles;
using Bottles.Diagnostics;
using Bottles.Exploding;
using Bottles.Manifest;
using FubuCore;

namespace FubuMVC.Core.Packaging
{
    public class ZipFilePackageLoader : IPackageLoader
    {
        public IEnumerable<IPackageInfo> Load(IPackageLog log)
        {
            var exploder = BottleExploder.GetPackageExploder(log);
            var reader = new BottleManifestReader(new FileSystem(), GetContentFolderForPackage);

            return FubuMvcPackageFacility.GetPackageDirectories().SelectMany(dir =>
            {
                return exploder.ExplodeDirectory(new ExplodeDirectory(){
                    DestinationDirectory = FubuMvcPackageFacility.GetExplodedPackagesDirectory(),
                    BottleDirectory = dir,
                    Log = log
                });
            }).Select(dir => reader.LoadFromFolder(dir));
        }

        public static string GetContentFolderForPackage(string packageFolder)
        {
            return FileSystem.Combine(packageFolder, BottleFiles.WebContentFolder);
        }
    }
}