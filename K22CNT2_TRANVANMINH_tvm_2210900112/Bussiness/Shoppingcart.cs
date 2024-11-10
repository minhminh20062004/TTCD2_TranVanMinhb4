﻿using K22CNT2_TRANVANMINH_tvm_2210900112.ModelsViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace K22CNT2_TRANVANMINH_tvm_2210900112.Bussiness
{
    public class ShoppingCart
    {
        public List<CartItem> Items { get; set; }
        public ShoppingCart()
        {
            Items = new List<CartItem>();
        }
        public void UpdateToCart(int id, int qty)
        {
            var existingItem = Items.FirstOrDefault(i => i.Id == id);
            if (existingItem != null)
            {
                existingItem.Qty = qty;
            }
        }
        public void AddToCart(CartItem item)
        {
            var existingItem = Items.FirstOrDefault(i => i.Id == item.Id);
            if (existingItem != null)
            {
                existingItem.Qty += item.Qty;
            }
            else
            {
                Items.Add(item);
            }
        }
            public void RemoveFromCart(int productId)
            {
                var itemToremove = Items.FirstOrDefault(i => i.Id == productId);
                if (itemToremove != null)
                {
                    Items.Remove(itemToremove);
                }
            }
            public float GetTotal()
              {
                   return Items.Sum(i => i.Price * i.Qty);
              }

    }
}
