﻿using jQueryApi;
using jQueryApi.UI.Widgets;
using System.Collections.Generic;

namespace Serenity
{
    /// <summary>
    /// Provides tabs extension methods
    /// </summary>
    public static class TabsExtensions
    {
        public static void SetDisabled(this TabsObject tabs, string tabKey, bool isDisabled)
        {
            if (tabs == null)
                return;

            var indexByKey = tabs.IndexByKey();
            if (indexByKey == null)
                return;

            var index = indexByKey[tabKey];
            if (index == null)
                return;

            if (index.Value == (int)tabs.Active)
                tabs.Active = 0;

            if (isDisabled)
                tabs.Disable(index.Value);
            else
                tabs.Enable(index.Value);
        }

        public static string ActiveTabKey(this TabsObject tabs)
        {
            var href = tabs.As<jQueryObject>().Children("ul").Children("li").Eq(tabs.Active.As<int>()).Children("a").GetAttribute("href").ToString();
            var prefix = "_Tab";
            var lastIndex = href.LastIndexOf(prefix);
            if (lastIndex >= 0)
                href = href.Substr(lastIndex + prefix.Length);
            return href;
        }

        public static JsDictionary<string, int?> IndexByKey(this TabsObject tabs)
        {
            var indexByKey = tabs.As<jQueryObject>().GetDataValue("indexByKey").As<JsDictionary<string, int?>>();
            if (indexByKey == null)
            {
                indexByKey = new JsDictionary<string, int?>();

                tabs.As<jQueryObject>().Children("ul").Children("li").Children("a")
                    .Each((index, el) =>
                    {
                        var href = el.GetAttribute("href").ToString();
                        var prefix = "_Tab";
                        var lastIndex = href.LastIndexOf(prefix);
                        if (lastIndex >= 0)
                            href = href.Substr(lastIndex + prefix.Length);

                        indexByKey[href] = index;
                    });

                tabs.As<jQueryObject>().Data("indexByKey", indexByKey);
            }

            return indexByKey;
        }
    }
}