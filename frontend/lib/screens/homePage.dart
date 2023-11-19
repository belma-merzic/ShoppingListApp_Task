import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import '../models/item.dart';
import '../models/shopper.dart';
import '../providers/item_provider.dart';
import '../providers/shopper_provider.dart';
import '../providers/shoppingList_provider.dart';

class MyHomePage extends StatefulWidget {
  const MyHomePage({Key? key}) : super(key: key);

  @override
  State<MyHomePage> createState() => _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage> {
  List<Shopper> shoppers = [];
  List<Item> items = [];
  late ShopperProvider _shopperProvider;
  late ShoppingListProvider _shoppingListProvider;
  late ItemProvider _itemProvider;
  int? selectedShopper;

  @override 
  void initState() {
    super.initState();
    _shopperProvider = Provider.of<ShopperProvider>(context, listen: false);
    _shoppingListProvider = Provider.of<ShoppingListProvider>(context, listen: false);
    _itemProvider = Provider.of<ItemProvider>(context, listen: false);

    fetchShoppers();
    fetchItems();
  }

  Future<void> fetchShoppers() async {
    try{
      var data = await _shopperProvider.get();
       setState(() {
      shoppers = data;
      selectedShopper = shoppers[0].shopperId;
    });
    }
    catch(e){
      print(e);
    }
  }


    Future<void> fetchItems() async {
    try{
      var data = await _itemProvider.get();
       setState(() {
      items = data;
    });
    }
    catch(e){
      print(e);
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Shopping List App'),
      ),
      body: SingleChildScrollView(
        child : Container(
        color: const Color.fromARGB(255, 255, 255, 255),
        child: Padding(
          padding: const EdgeInsets.all(24.0),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: <Widget>[
              Center(
                child: Column(
                  children: [
                    const Text(
                      'Select Shopper:',
                      style: TextStyle(fontSize: 18),
                    ),
                  DropdownButton<int>(
                    value: selectedShopper,
                    items: shoppers.map((Shopper shopper) {
                      return DropdownMenuItem<int>(
                    value: shopper.shopperId,
                    child: Text(shopper.shopperName!),
                    );
                  }).toList(),
                  onChanged: (int? newValue) {
                  setState(() {
                  selectedShopper = newValue;
                  });
                  },
                ),
                  ],
                ),
              ),
              const SizedBox(height: 20),
              GridView.builder(
                shrinkWrap: true,
                gridDelegate: const SliverGridDelegateWithFixedCrossAxisCount(
                crossAxisCount: 5,
                crossAxisSpacing: 16.0,
                mainAxisSpacing: 16.0,
              ),
          itemCount: items.length,
          itemBuilder: (BuildContext context, int index) {
          final Item currentItem = items[index];
        return Card(
      elevation: 2.0,
      shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.circular(8.0),
      ),
      child: SizedBox(
        width: 200.0,
        height: 200.0,
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            ConstrainedBox(
              constraints: BoxConstraints(
                maxWidth: 150.0,
                maxHeight: 120.0,
              ),
              child: Center(
                child: Image.asset(
                  'assets/background.jpg', 
                  fit: BoxFit.cover,
                ),
              ),
            ),
            const SizedBox(height: 8),
            Text(currentItem.itemName!),
            const SizedBox(height: 8),
            ElevatedButton(
              onPressed: () {
                if (selectedShopper != null) {
                  var request = {
                    'shopperId': selectedShopper,
                    'itemId': currentItem.itemId,
                  };
                  try{
                  _shoppingListProvider.insert(request);
                  }catch(e){
                    print(e);
                  }
                }
              },
              child: const Text('Add'),
            ),
          ],
        ),
      ),
    );
  },
),
              const SizedBox(height: 20),
              Center(
                child: ElevatedButton(
onPressed: () async {
  if (selectedShopper != null) {
    try {
      var list = await _shoppingListProvider.getById(selectedShopper!);

      showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            title: Text('Shopping list for Shopper ${selectedShopper}'),
            content: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              mainAxisSize: MainAxisSize.min,
              children: list.map((item) {
                return Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text('Item ID: ${item.itemId}'),
                    SizedBox(height: 10), 
                  ],
                );
              }).toList(),
            ),
            actions: [
              TextButton(
                onPressed: () {
                  Navigator.of(context).pop(); 
                },
                child: Text('Close'),
              ),
            ],
          );
        },
      );
    } catch (e) {
      print('Error fetching shopping list details: $e');
    }
  }
},
  child: const Text('LOOK AT CREATED SHOPPING LIST'),
),
              ),
            ],
          ),
        ),
      ),
      ),
    );
  }
}

