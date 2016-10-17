using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAttributes
{
	public class Separators : ICollection<string>, IList<string>
	{
		private List<string> Collection = new List<string>();

		public Separators()
		{

		}

		public Separators(List<string> StringSeparators)
		{
			StringSeparators.ForEach(x => this.Add(x));
		}

		public Separators(string Separator, bool IsCharList = true)
		{
			if (IsCharList)
				Separator.ToList<char>().ForEach(x => ((ICollection<String>)Collection).Add(x.ToString()));
			else
				((ICollection<String>)Collection).Add(Separator);
		}

		public String this[Int32 index]
		{
			get
			{
				return ((IList<String>)Collection)[index];
			}

			set
			{
				((IList<String>)Collection)[index] = value;
			}
		}

		public Int32 Count
		{
			get
			{
				return ((ICollection<String>)Collection).Count;
			}
		}

		public Boolean IsReadOnly
		{
			get
			{
				return ((ICollection<String>)Collection).IsReadOnly;
			}
		}

		public void Add(String item)
		{
			((ICollection<String>)Collection).Add(item);
		}

		public void Add(String item, bool IsCharList = false)
		{
			if (IsCharList)
				item.ToList<char>().ForEach(x => ((ICollection<String>)Collection).Add(x.ToString()));
			else
				((ICollection<String>)Collection).Add(item);
		}

		public void Clear()
		{
			((ICollection<String>)Collection).Clear();
		}

		public Boolean Contains(String item)
		{
			return ((ICollection<String>)Collection).Contains(item);
		}

		public void CopyTo(String[] array, Int32 arrayIndex)
		{
			((ICollection<String>)Collection).CopyTo(array, arrayIndex);
		}

		public IEnumerator<String> GetEnumerator()
		{
			return ((ICollection<String>)Collection).GetEnumerator();
		}

		public Int32 IndexOf(String item)
		{
			return ((IList<String>)Collection).IndexOf(item);
		}

		public void Insert(Int32 index, String item)
		{
			((IList<String>)Collection).Insert(index, item);
		}

		public Boolean Remove(String item)
		{
			return ((ICollection<String>)Collection).Remove(item);
		}

		public void RemoveAt(Int32 index)
		{
			((IList<String>)Collection).RemoveAt(index);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((ICollection<String>)Collection).GetEnumerator();
		}
	}
}
