using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.EntityClient;

namespace Landlord2
{
	class AppRoot
	{		
		private static AppRoot instance = null;//将AppRoot设计为单件模式
		private static EntityConnection connection;

		/// <summary>
		/// EntityConnection标志（值为1、2）。
		/// flag = 1 ：初始构造一个连接，并常开。其他窗体用各自新建的连接（默认情况下， EF的context根据需要开关连接）。整个应用结束时销毁初始打开的连接。
		/// flag = 2 ：整个应用使用同一个连接，初始构造并常开，应用结束销毁。
		/// </summary>
		public static int EntityConnectionFlag = 1;//默认用1方式

		/// <summary>
		/// 此项目因为用sql compact作为数据库，因为连接的open,close费用太大，所以此项目用以下2种模式：
		/// 1、初始构造一个连接，并常开。其他窗体用各自新建的连接（默认情况下， EF的context根据需要开关连接）。整个应用结束时销毁初始打开的连接。
		/// 2、整个应用使用同一个连接，初始构造并常开，应用结束销毁。
		/// 参考文献：
		/// 1、Working with Objects (Entity Framework 4.1)http://msdn.microsoft.com/en-us/library/gg696163(v=VS.103).aspx
		/// 2、c# - To close or not to close connection in database - Stack Overflow http://stackoverflow.com/questions/4962021/to-close-or-not-to-close-connection-in-database
		/// </summary>
		public static EntityConnection MyConnection
		{
			get 
			{
				if (EntityConnectionFlag == 1)
				{
					if (connection == null)
					{
						connection = new EntityConnection(Helper.CreateConnectString());
						connection.Open();
						return connection;
					}
					else
						return new EntityConnection(Helper.CreateConnectString());
				}
				else
				{
					if (connection == null)
					{
						connection = new EntityConnection(Helper.CreateConnectString());
						connection.Open();
					}
					return connection;
				}

			}
		}
		
		private AppRoot()
		{
			
		}
		public static AppRoot getInstance()
		{
			if(instance == null)
				instance = new AppRoot();
			return instance;
		}

		/// <summary>
		/// 初始化AppRoot
		/// </summary>
		public static void Inital()
		{
			//模型对象初始化
			instance = null;
			instance = new AppRoot();

			//连接初始化
			if (connection != null)
				connection.Dispose();
			connection = new EntityConnection(Helper.CreateConnectString());
			connection.Open();
		}  
	}
}
