using MP.Author.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MP.Author.Core.Converts
{
    public class ObjectsRecusiver
    {
        public static List<ObjectDto> ReturnObjects(List<ObjectDto> source, List<ObjectDto> parentRoot)
        {            
            foreach (var item in parentRoot)
            {
                RecusiveObjects(source, item, parentRoot);
            }
            
            return parentRoot;
        }

        private static List<ObjectDto> RecusiveObjects(List<ObjectDto> childs, ObjectDto parents, List<ObjectDto> target)
        {
            var objChild = childs.Where(x => x.ParentId.Equals(parents.Id));
            if (objChild != null && objChild.Count() > 0)
            {
                //parents.children = objChild.Where(x=>x.IsPage).ToList();
                parents.children = objChild.ToList();
                //target.Add(parents);
                foreach (var child in objChild)
                {
                    return RecusiveObjects(childs, child, target);
                }
            }            
            return target;
        }
    }
}
