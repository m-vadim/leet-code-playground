﻿namespace LeetCode;

public interface ILRUCache {
	int Get(int key);
	void Put(int key, int value);
}