using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;
using ModelNhaXinh.Dao;
using NhaXinhBUS.common;

namespace NhaXinhBUS.BUS
{
	public partial class ContentBUS
	{
		ContentDAO contentDAO = new ContentDAO();
		List<Content> list;

		public List<Content> getAllContent()
		{
			list = contentDAO.getAllContent();
			return list;

		}

		public List<CategoryNew> GetAllCat()
		{
			return contentDAO.getAllCAT();
		}

		public Content getByID(int id)
		{
			return contentDAO.getbyID(id);
		}

		public int Create(Content content)
		{
			//xử lý alias
			if(string.IsNullOrEmpty(content.MetaTitle))
			{
				content.MetaTitle = Stringhelper.ConvertToUnSign(content.Name);
			}
			contentDAO.Create(content);
			//xử lý Tags
			if(!string.IsNullOrEmpty(content.Tags))
			{
				string[] tags = content.Tags.Split(',');
				foreach(var tag in tags)
				{
					var tagID = Stringhelper.ConvertToUnSign(tag);
					var existedTag = contentDAO.CheckTag(tagID);

					if(!existedTag)
					{
						Tag newtag = new Tag();
						newtag.TagID = tagID;
						newtag.Name = tag;
						contentDAO.insertTag(newtag);
					}
					ContentTag newCtag = new ContentTag();
					newCtag.ContentID = content.ContentID;
					newCtag.TagID = tagID;
					contentDAO.InsertContentTag(newCtag);
				}
			}
			return content.ContentID;
		}

		public int Edit(Content content)
		{
			//xử lý alias
			if (string.IsNullOrEmpty(content.MetaTitle))
			{
				content.MetaTitle = Stringhelper.ConvertToUnSign(content.Name);
			}
			contentDAO.Edit(content);
			//xử lý Tags
			if (!string.IsNullOrEmpty(content.Tags))
			{
				contentDAO.RemoveAllContentTag(content.ContentID);
				string[] tags = content.Tags.Split(',');
				foreach (var tag in tags)
				{
					var tagID = Stringhelper.ConvertToUnSign(tag);
					var existedTag = contentDAO.CheckTag(tagID);

					if (!existedTag)
					{
						Tag newtag = new Tag();
						newtag.TagID = tagID;
						newtag.Name = tag;
						contentDAO.insertTag(newtag);
					}
					ContentTag newCtag = new ContentTag();
					newCtag.ContentID = content.ContentID;
					newCtag.TagID = tagID;
					contentDAO.InsertContentTag(newCtag);
				}
			}
			return content.ContentID;
		}

		public List<Tag> ListTags(int contentID)
		{
			return contentDAO.listTags(contentID);
		}

		public List<Content> getByTag(string TagID)
		{
			return contentDAO.getListByTag(TagID);
		}

		public Tag GetTag(string id)
		{
			return contentDAO.GetTag(id);
		}
	}
}
