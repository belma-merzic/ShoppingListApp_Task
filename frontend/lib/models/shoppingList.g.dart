// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'shoppingList.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

ShoppingList _$ShoppingListFromJson(Map<String, dynamic> json) => ShoppingList(
      json['shoppingListId'] as int?,
      json['shopperId'] as int?,
      json['itemId'] as int?,
    );

Map<String, dynamic> _$ShoppingListToJson(ShoppingList instance) =>
    <String, dynamic>{
      'shoppingListId': instance.shoppingListId,
      'shopperId': instance.shopperId,
      'itemId': instance.itemId,
    };
