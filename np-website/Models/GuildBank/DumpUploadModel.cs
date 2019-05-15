using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace np_website.Models.GuildBank
{
    public class DumpUploadModel
    {
        [Required(ErrorMessage = "Please select one or more files.")]
        [Display(Name = "Browse File")]
        public HttpPostedFileBase[] files { get; set; }

        private enum inventoryDumpColumns : int
        {
            Location = 0,
            Name = 1,
            ID = 2, 
            Count = 3,
            Slots = 4
        }

        public List<DumpDataModel> ProcessFiles()
        {
            var items = new List<DumpDataModel>();

            foreach (var file in files)
            {
                var characterName = file.FileName.Split('_')[0];
                byte[] data;

                using (var reader = new BinaryReader(file.InputStream))
                    data = reader.ReadBytes(file.ContentLength);

                var dump = System.Text.Encoding.UTF8.GetString(data);
                var rows = dump.Split(new char[] { '\r', '\n' });
                for (int i = 1; i < rows.Length; i++)
                {
                    if (!string.IsNullOrEmpty(rows[i]))
                    {
                        var rowData = rows[i].Split('\t');

                        if(int.Parse(rowData[(int)inventoryDumpColumns.Count]) > 0)
                        {
                            items.Add(new DumpDataModel()
                            {
                                CharacterName = characterName,
                                Location = rowData[(int)inventoryDumpColumns.Location],
                                Name = rowData[(int)inventoryDumpColumns.Name],
                                ID = int.Parse(rowData[(int)inventoryDumpColumns.ID]),
                                Count = int.Parse(rowData[(int)inventoryDumpColumns.Count]),
                                Slots = int.Parse(rowData[(int)inventoryDumpColumns.Slots])
                            });
                        }

                    }
                }
            }

            return items;
        }

    }
}