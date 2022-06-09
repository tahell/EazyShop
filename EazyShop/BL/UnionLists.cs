using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
  
    class UnionLists
    {
    //    List<Products> ThreeOrders = new List<Products>();
    //    static DBConection db = new DBConection();
    //    public static Dictionary<ThreeOrders, int> _dicThird;
    //    static ThreeOrders _tempThird;
    //    public static void CreateCombination()
    //    {
    //        _dicThird = new Dictionary<ThreeOrders, int>();

    //        int _numOfOrders = 0;
    //        foreach (Reserved_lists orderI in db._dicOrdersItems.Keys)
    //        {
    //            _numOfOrders = 1;
    //            foreach (Reserved_lists orderJ in db._dicOrdersItems.Keys)
    //            {
    //                if (orderI == orderJ) continue;
    //                _numOfOrders = 2;
    //                foreach (Reserved_lists orderK in db._dicOrdersItems.Keys)
    //                {
    //                    if (orderI == orderK || orderJ == orderK) continue;
    //                    _numOfOrders = 3;
    //                    _tempThird = new ThreeOrders() { first = orderI, second = orderJ, Third = orderK };
    //                    if (!_dicThird.ContainsKey(_tempThird))
    //                    {
    //                        _tempThird.value = CalcValueThreeOrders(orderI, orderJ, orderK);
    //                        _dicThird.Add(_tempThird, _tempThird.value);
    //                    }
    //                }
    //                if (_numOfOrders == 2)
    //                {
    //                    _tempThird = new ThreeOrders() { first = orderI, second = orderJ, Third = new Reserved_lists() { List_code = 0 } };
    //                    if (!_dicThird.ContainsKey(_tempThird))
    //                        _dicThird.Add(_tempThird, 0);
    //                    break;
    //                }
    //            }
    //            if (_numOfOrders == 1)
    //            {
    //                _tempThird = new ThreeOrders() { first = orderI, second = new Reserved_lists { List_code = 0 }, Third = new Reserved_lists() { List_code = 0 } };
    //                if (!_dicThird.ContainsKey(_tempThird))
    //                    _dicThird.Add(_tempThird, 0);
    //                break;
    //            }

    //        }
    //    }

    //    //מחזיר רשימת פריטים של 3 הזמנות בעלות ערך ההתאמה הגבוהה ביותר ברשימה
    //    public static List<Products> GetItemsOfThreeBestOrders()
    //    {
    //        List<Products> _listItemsToSupplay = new List<Products>();
    //        ThreeOrders _threeOrders = new ThreeOrders();
    //        if (_dicThird != null && _dicThird.Count != 0)
    //        {
    //            int _maxValue = _dicThird.OrderByDescending(r => r.Value).FirstOrDefault().Value;
    //            _threeOrders = _dicThird.Where(x => x.Value == _maxValue).FirstOrDefault().Key;

    //            foreach (Products _item in db._dicOrdersItems[_threeOrders.first])
    //            {
    //                if (!_listItemsToSupplay.Contains(_item)) _listItemsToSupplay.Add(_item);
    //            }
    //            if (_threeOrders.second.OrderID != 0)
    //                foreach (Products _item in db._dicOrdersItems[_threeOrders.second])
    //                {
    //                    if (!_listItemsToSupplay.Contains(_item)) _listItemsToSupplay.Add(_item);
    //                }
    //            if (_threeOrders.Third.OrderID != 0)
    //                foreach (Products _item in db._dicOrdersItems[_threeOrders.Third])
    //                {
    //                    if (!_listItemsToSupplay.Contains(_item)) _listItemsToSupplay.Add(_item);
    //                }

    //        }

    //        return _listItemsToSupplay;
    //    }

    //    //מחזיר אוביקט של 3 הזמנות בעלות ערך ההתאמה הגבוהה ביותר ברשימה
    //    public static ThreeOrders GetThreeBestOrders()
    //    {
    //        ThreeOrders _threeOrders = new ThreeOrders();
    //        if (_dicThird != null)
    //        {
    //            int _maxValue = _dicThird.OrderByDescending(r => r.Value).FirstOrDefault().Value;
    //            _threeOrders = _dicThird.Where(x => x.Value == _maxValue).FirstOrDefault().Key;
    //        }
    //        return _threeOrders;
    //    }

    //    //טיפול בחישוב של מס' ההתאמות בין הזמנות
    //    public static int CalcValueThreeOrders(Reserved_lists orderId1, Reserved_lists orderId2, Reserved_lists orderId3)
    //    {
    //        int _value = 0;

    //        List<int> _departmentList1 = db._dicOrdersItems[orderId1].Select(x => x.DepartmentsID).Distinct().ToList();
    //        List<int> _departmentList2 = db._dicOrdersItems[orderId2].Select(x => x.DepartmentsID).Distinct().ToList();
    //        List<int> _departmentList3 = db._dicOrdersItems[orderId3].Select(x => x.DepartmentsID).Distinct().ToList();

    //        _value = CalcValueTwoOrders(_departmentList1, _departmentList2) +
    //                 CalcValueTwoOrders(_departmentList1, _departmentList3) +
    //                 CalcValueTwoOrders(_departmentList2, _departmentList3);

    //        return _value;
    //    }

    //    //חישוב של מס' ההתאמות שבין מחלקות 2 הזמנות 
    //    public static int CalcValueTwoOrders(List<int> departmentList1, List<int> departmentList2)
    //    {
    //        return (from x in departmentList1
    //                from y in departmentList2
    //                where x == y
    //                select x).Count();

    //    }
    //}
}
}
