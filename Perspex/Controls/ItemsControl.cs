﻿// -----------------------------------------------------------------------
// <copyright file="ItemsControl.cs" company="Steven Kirk">
// Copyright 2014 MIT Licence. See licence.md for more information.
// </copyright>
// -----------------------------------------------------------------------

namespace Perspex.Controls
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ItemsControl : TemplatedControl
    {
        private static readonly ItemsPanelTemplate DefaultPanel =
            new ItemsPanelTemplate(() => new StackPanel { Orientation = Orientation.Vertical });

        public static readonly PerspexProperty<IEnumerable> ItemsProperty =
            PerspexProperty.Register<ItemsControl, IEnumerable>("Items");

        public static readonly PerspexProperty<ItemsPanelTemplate> ItemsPanelProperty =
            PerspexProperty.Register<ItemsControl, ItemsPanelTemplate>("ItemsPanel", defaultValue: DefaultPanel);

        private Dictionary<object, Control> itemControls = new Dictionary<object, Control>();

        public ItemsControl()
        {
            this.GetObservable(ItemsProperty).Subscribe(this.ItemsChanged);
        }

        public IEnumerable Items
        {
            get { return this.GetValue(ItemsProperty); }
            set { this.SetValue(ItemsProperty, value); }
        }

        public ItemsPanelTemplate ItemsPanel
        {
            get { return this.GetValue(ItemsPanelProperty); }
            set { this.SetValue(ItemsPanelProperty, value); }
        }

        public Control GetControlForItem(object item)
        {
            Control result;
            this.itemControls.TryGetValue(item, out result);
            return result;
        }

        public IEnumerable<Control> GetAllItemControls()
        {
            return this.itemControls.Values;
        }

        internal Control CreateItemControl(object item)
        {
            Control control = this.CreateItemControlOverride(item);
            this.itemControls.Add(item, control);
            return control;
        }

        protected virtual Control CreateItemControlOverride(object item)
        {
            return (item as Control) ?? this.GetDataTemplate(item).Build(item);
        }

        private void ItemsChanged(IEnumerable items)
        {
            if (items == null || !items.OfType<object>().Any())
            {
                this.Classes.Add(":empty");
            }
            else
            {
                this.Classes.Remove(":empty");
            }
        }
    }
}
