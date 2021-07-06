/// main source:  see description in accompanying README.md

namespace NameSorter
{
	using System.Linq;

	public class NameSorter
	{
		/// Vital fucntion of the program. 
		public static string [] sortedNames (string fileName)
		{
			string [] names = System.IO.File.ReadAllLines(fileName);
			// get a parallel array for sorting
			var sortKey = names.Select(theLastWillBeFirst).ToArray();
			System.Array.Sort(sortKey, names);
			return names;
		}

		public static void Main (string [] args)
		{
			// Take each argument as a filename:
			foreach (string arg in args)
			{
				var names = sortedNames(arg);
				foreach (string name in names)
				{
					System.Console.WriteLine(name);
				}
				System.IO.File.WriteAllLines(@"sorted-names-list.txt", names);
			}
		}

		private static string theLastWillBeFirst (string name)
		{
			// break up the name into words
			var names = name.Split(' ', System.StringSplitOptions.None);
			var length = names.Length;
			// put the surname at the front
			return names[length - 1] + ' ' + string.Join(' ', names, 0, length - 1);
		}
	}
}
