using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelNhaXinh.EF;

namespace ModelNhaXinh.Dao
{
	public partial class ContentDAO
	{
		NhaXinhEntities db = new NhaXinhEntities();

		public List<CategoryNew> getAllCAT()
		{
			return db.CategoryNews.ToList();
		}

		public List<Content> getListByTag(string tagID)
		{
			var model = (from a in db.Contents
					join b in db.ContentTags
					on a.ContentID equals b.ContentID
					where b.TagID == tagID 				 
					select new
					{
						Name = a.Name,
						metatitle = a.MetaTitle,
						image = a.Image,
						description = a.Description,
						CreateDate = a.CreateDate,
						CreateBy = a.CreateBy,
						ID = a.ContentID,
						Details = a.Details
					}).AsEnumerable().Select(s => new Content()
					{
						ContentID = s.ID,
						Name = s.Name,
						MetaTitle = s.metatitle,
						Image = s.image,
						Description = s.description,
						CreateDate = s.CreateDate,
						CreateBy = s.CreateBy,
						Details = s.Details
					});
			return model.OrderByDescending(s => s.CreateDate).ToList();
		}

		public List<Content> getAllContent()
		{
			return db.Contents.ToList();
		}

		public Content getbyID(int id)
		{
			return db.Contents.Find(id);
		}

		public void Create(Content content)
		{
			db.Contents.Add(content);
			db.SaveChanges();
		}

		public void Edit(Content content)
		{
			Content newsp = db.Contents.Find(content.ContentID);
			if (newsp != null)
			{
				newsp.Tags = content.Tags;
				newsp.MetaTitle = content.MetaTitle;
				newsp.Name = content.Name;
				newsp.Image = content.Image;
				newsp.Description = content.Description;
				newsp.MetaDescriptions = content.MetaDescriptions;
				newsp.Details = content.Details;
				newsp.ViewCount = content.ViewCount;
				newsp.Language = content.Language;
				newsp.CatID = content.CatID;
			}
			db.SaveChanges();
		}

		public bool CheckTag(string id)
		{
			return db.Tags.Count(s => s.TagID == id) > 0;
		}

		public void insertTag(Tag tag)
		{

			db.Tags.Add(tag);
			db.SaveChanges();
		}

		public void InsertContentTag(ContentTag contentTag)
		{
			db.ContentTags.Add(contentTag);
			db.SaveChanges();

		}
		public void RemoveAllContentTag(int contentID)
		{
			db.ContentTags.RemoveRange(db.ContentTags.Where(s => s.ContentID == contentID));
			db.SaveChanges();
		}

		public List<Tag> listTags(int contentID)
		{
			var model = (from a in db.Tags
						join b in db.ContentTags
						on a.TagID equals b.TagID
						where b.ContentID == contentID
						select new 
						{
							ID = b.TagID,
							Name = a.Name
						}).AsEnumerable().Select(x=> new Tag()
						{
							TagID = x.ID,
							Name = x.Name
						});
			return model.ToList();
		}

		public Tag GetTag(string id)
		{
			return db.Tags.Find(id);
		}
	}
}
