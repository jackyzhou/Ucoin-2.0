﻿using System.Collections.Generic;
using System.Linq;
using System;
using Ucoin.Framework.Cache;

namespace Ucoin.Framework.MongoDb.Managers
{
    public static class CacheHelper
    {
        public static readonly string NodeKey = "Cache_Tree_Nodes";


        public static List<TreeNode> GetTreeNodes()
        {
            var expDate = DateTime.Now.AddHours(2);
            var cache = CachePolicy.WithAbsoluteExpiration(expDate);
            var nodes = Ucoin.Framework.Cache.CacheHelper.MemoryCache
                .Get<List<TreeNode>>(NodeKey, () => RealGetTreeNodes(), cache);
            // MemoryCacheHelper.GetCacheItem(NodeKey, () => RealGetTreeNodes(), null, expDate);
            return nodes;
        }

        private static List<TreeNode> RealGetTreeNodes()
        {
            var context = new MongoContext();
            var nodes = context.TreeNodes.ToList();
            return nodes;
        }


        public static TreeNode GetTreeNode(int id)
        {
            var nodes = GetTreeNodes();
            return nodes.Single(i => i.Id == id);
        }

        public static TreeNode GetParentTreeNode(int id)
        {
            var node = GetTreeNode(id);
            return GetTreeNode(node.PId);
        }

        public static IModel GetMongoModelInfo(int id)
        {
            IModel model = null;
            var node = GetTreeNode(id);
            if (node != null)
            {
                model = node.ModelInfo;
            }
            return model;
        }

        public static void Clear()
        {
            Ucoin.Framework.Cache.CacheHelper.MemoryCache.Remove(NodeKey);
            //MemoryCacheHelper.Remove(NodeKey);
        }
    }
}
