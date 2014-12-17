﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

using RGiesecke.DllExport;
using GSharp;

namespace binarylua_win32 {
	public unsafe static class Binarylua {

		[DllExport(ExportName = "gmod13_open", CallingConvention = CallingConvention.Cdecl)]
		public static void Open(IntPtr L) {
			Lua.PushCFunction(L, (LL) => {
				int Len = 0;
				char* Bytecode = (char*)Lua.ToLString(L, -1, new IntPtr(&Len)).ToPointer();
				if (Lua.LoadBuffer(LL, Bytecode, Len, "binarychunk") != 0)
					return 0;
				return 1;
			});
			Lua.SetField(L, Lua.GLOBALSINDEX, "binaryload");
		}

		[DllExport(ExportName = "gmod13_close", CallingConvention = CallingConvention.Cdecl)]
		public static void Close(IntPtr L) {

		}

	}
}