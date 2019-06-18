using System;
namespace RESCommonModel
{
	/// <summary>
	/// spiderdata:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class spiderdata
	{
		public spiderdata()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _content;
		private string _firstkind;
		private string _secondkind;
		private string _kindname;
		private string _kindcode;
		private DateTime? _inserttime;
		private DateTime? _releasetime;
		private string _author;
		private string _resource;
		private string _coverimage;
		private string _spiderurl;
		private int? _browsecount;
		private string _isrelease;
		private string _isdelete;
		private string _remark;
		private string _applyplatform;
		private string _ext1;
		private string _ext2;
		private string _ext3;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string firstKind
		{
			set{ _firstkind=value;}
			get{return _firstkind;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string secondKind
		{
			set{ _secondkind=value;}
			get{return _secondkind;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string kindName
		{
			set{ _kindname=value;}
			get{return _kindname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string kindCode
		{
			set{ _kindcode=value;}
			get{return _kindcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? insertTime
		{
			set{ _inserttime=value;}
			get{return _inserttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? releaseTime
		{
			set{ _releasetime=value;}
			get{return _releasetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string author
		{
			set{ _author=value;}
			get{return _author;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string resource
		{
			set{ _resource=value;}
			get{return _resource;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string coverImage
		{
			set{ _coverimage=value;}
			get{return _coverimage;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string spiderUrl
		{
			set{ _spiderurl=value;}
			get{return _spiderurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? browseCount
		{
			set{ _browsecount=value;}
			get{return _browsecount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string isRelease
		{
			set{ _isrelease=value;}
			get{return _isrelease;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string isDelete
		{
			set{ _isdelete=value;}
			get{return _isdelete;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string applyplatform
		{
			set{ _applyplatform=value;}
			get{return _applyplatform;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ext1
		{
			set{ _ext1=value;}
			get{return _ext1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ext2
		{
			set{ _ext2=value;}
			get{return _ext2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ext3
		{
			set{ _ext3=value;}
			get{return _ext3;}
		}
		#endregion Model

	}
}

