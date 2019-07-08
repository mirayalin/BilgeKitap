using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCUI.Models.MyEntities
{
    public class Cart
    {

        Dictionary<int, CartItem> _sepetim = new Dictionary<int, CartItem>();

        public List<CartItem> Sepetim
        {
            get
            {
                return _sepetim.Values.ToList();
            }
        }

        //BU metodumuz kendi icerisinde bir kontrol yaparak calısacak. Eger kullanıcı daha önce bir ürünü secmişs onun adedini arttıracak secmemişse ekleyecek...

        public void SepeteEkle(CartItem item)
        {
            if (_sepetim.ContainsKey(item.ID))
            {
                _sepetim[item.ID].Amount += 1;
                return;
            }

            _sepetim.Add(item.ID, item);
        }

        public void SepettenSil(int id)
        {
            if (_sepetim[id].Amount > 1)
            {
                _sepetim[id].Amount -= 1;
                return;
            }

            _sepetim.Remove(id);
        }
    }
}