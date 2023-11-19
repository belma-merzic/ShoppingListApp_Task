import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:http/http.dart';
import '../models/search_result.dart';

abstract class BaseProvider<T> with ChangeNotifier{ 
  static String? _baseUrl;
  String _endpoint = "";

 BaseProvider(String endpoint){
  _endpoint = endpoint;
  _baseUrl = const String.fromEnvironment("baseUrl", defaultValue: "http://localhost:7000/");
 } 

  Future<List<T>> get() async {
    try {
      final response = await http.get(Uri.parse('$_baseUrl$_endpoint'));
      
      if (response.statusCode == 200) {
        final List<dynamic> jsonData = json.decode(response.body);
        final List<T> data = jsonData.map((item) => mapFromJson(item)).toList();
        return data;
      } else {
        throw Exception('Failed to load data');
      }
    } catch (e) {
      throw Exception('Error: $e');
    }
  }


Future<T> insert(dynamic request) async {
    try {
      final response = await http.post(
        Uri.parse('$_baseUrl$_endpoint'),
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
        },
        body: jsonEncode(request),
      );

      if (response.statusCode == 201) {
        final dynamic jsonData = json.decode(response.body);
        return mapFromJson(jsonData);
      } else {
        throw Exception('Failed to insert data');
      }
    } catch (e) {
      throw Exception('Error: $e');
    }
  }

Future<List<T>> getById(int id) async {
  try {
    final response = await http.get(Uri.parse('$_baseUrl$_endpoint/$id'));

    if (response.statusCode == 200) {
      final List<dynamic> jsonData = json.decode(response.body);
      final List<T> data = jsonData.map((item) => mapFromJson(item)).toList();
      return data;
    } else {
      throw Exception('Failed to fetch items with ID $id');
    }
  } catch (e) {
    throw Exception('Error: $e');
  }
}

  T mapFromJson(Map<String, dynamic> json); 

}
