﻿
using API_HRIS.Manager;
using API_HRIS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using Org.BouncyCastle.Utilities;
using System.Data;
using System.Drawing.Printing;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.IdentityModel.Tokens;
using API_HRIS.ApplicationModel;
using System.Text;
using static API_HRIS.ApplicationModel.EntityModels;

namespace API_HRIS.Controllers
{
    [Authorize("ApiKey")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly ODC_HRISContext _context;
        DbManager db = new DbManager();
        DBMethods dbmet = new DBMethods();
        public class BirthTypesSearchFilter
        {
            public string? BirthTypeCode { get; set; }
            public string? BirthTypeDesc { get; set; }
            public int page { get; set; }
            public int pageSize { get; set; }
        }

        public PositionController(ODC_HRISContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> PositionList()
        {
            return Ok(_context.TblPositionModels.Where(a => a.DeleteFlag == 0).OrderByDescending(a => a.Id).ToList());
        }

        [HttpPost]
        public async Task<IActionResult> PositionPaginationList(FilterPosition data)
        {
            int pageSize = 25;
            //var model_result = (dynamic)null;
            var items = (dynamic)null;
            int totalItems = 0;
            int totalPages = 0;
            string page_size = pageSize == 0 ? "10" : pageSize.ToString();
            try
            {

                var postion = _context.TblPositionModels.ToList();
                totalItems = postion.Count();
                totalPages = (int)Math.Ceiling((double)totalItems / int.Parse(page_size.ToString()));

                items = postion.Skip((data.page - 1) * int.Parse(page_size.ToString())).Take(int.Parse(page_size.ToString())).ToList();

                var result = new List<PositionPaginateModel>();
                var item = new PositionPaginateModel();
                int pages = data.page == 0 ? 1 : data.page;
                item.CurrentPage = data.page == 0 ? "1" : data.page.ToString();

                int page_prev = pages - 1;

                double t_records = Math.Ceiling(double.Parse(totalItems.ToString()) / double.Parse(page_size));
                int page_next = data.page >= t_records ? 0 : pages + 1;
                item.NextPage = items.Count % int.Parse(page_size) >= 0 ? page_next.ToString() : "0";
                item.PrevPage = pages == 1 ? "0" : page_prev.ToString();
                item.TotalPage = t_records.ToString();
                item.PageSize = page_size;
                item.TotalRecord = totalItems.ToString();
                item.items = items;
                result.Add(item);

                string status = "Positoin successfully viewed";
                dbmet.InsertAuditTrail("View All Position" + " " + status, DateTime.Now.ToString("yyyy-MM-dd"), "Position Module", "User", "0"); ;

                return Ok(result);


            }

            catch (Exception ex)
            {
                return BadRequest("ERROR");
            }
        }
        [HttpPost]
        public async Task<ActionResult<TblPositionModel>> save(TblPositionModel tblPositionModel)
        {
            if (_context.TblPositionModels == null)
            {
                return Problem("Entity set 'ODC_HRISContext.TblPositionModels'  is null.");
            }
            bool hasDuplicateOnSave = (_context.TblPositionModels?.Any(positionModel => positionModel.Name == tblPositionModel.Name)).GetValueOrDefault();

            if (tblPositionModel.Id == 0)
            {
                if (hasDuplicateOnSave)
                {
                    return Conflict("Entity already exists");
                }
            }
            try
            {
                //_context.TblPositionModels.Add(tblPositionModel);
                if (tblPositionModel.Id == 0)
                {
                    _context.TblPositionModels.Add(tblPositionModel);
                }
                else
                {
                    _context.Entry(tblPositionModel).State = EntityState.Modified;
                }
                await _context.SaveChangesAsync();

                string status = "Position successfully saved";
                dbmet.InsertAuditTrail("Save Position" + " " + status, DateTime.Now.ToString("yyyy-MM-dd"), "Position Module", "User", "0");
                return CreatedAtAction("save", new { id = tblPositionModel.Id }, tblPositionModel);
            }
            catch (Exception ex)
            {
                dbmet.InsertAuditTrail("Save Position" + " " + ex.Message, DateTime.Now.ToString("yyyy-MM-dd"), "Position Module", "User", "0");
                return Problem(ex.GetBaseException().ToString());
            }
        }
        [HttpPost]
        public async Task<ActionResult<TblPositionModel>> deletePosition(TblPositionModel data)
        {
            try
            {
                //_context.TblPositionModels.Add(tblPositionModel);
                string query = $@"UPDATE tbl_positionmodel
		                            SET DeleteFlag = 1"
                                    + " WHERE Id = '" + data.Id + "'";
                db.AUIDB_WithParam(query);

                string status = "Position successfully deleted";
                return Ok(status);
            }
            catch (Exception ex)
            {
                return Problem(ex.GetBaseException().ToString());
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> update(int id, TblPositionModel tblPositionModel)
        {
            if (_context.TblPositionModels == null)
            {
                return Problem("Entity set 'ODC_HRISContext.TblPositionModels'  is null.");
            }

            var positionModel = _context.TblPositionModels.AsNoTracking().Where(positionModel => positionModel.Id == id).FirstOrDefault();

            if (positionModel == null)
            {
                return Conflict("No records matched!");
            }

            if (id != positionModel.Id)
            {
                return Conflict("Ids mismatched!");
            }

            bool hasDuplicateOnUpdate = (_context.TblPositionModels?.Any(positionModel => positionModel.Name == tblPositionModel.Name)).GetValueOrDefault();

            // check for duplication
            if (hasDuplicateOnUpdate)
            {
                return Conflict("Entity already exists");
            }

            try
            {
                _context.Entry(tblPositionModel).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                string status = "Position successfully updated";
                dbmet.InsertAuditTrail("Update Position" + " " + status, DateTime.Now.ToString("yyyy-MM-dd"), "Position Module", "User", "0");

                return Ok("Update Successful!");
            }
            catch (Exception ex)
            {
                dbmet.InsertAuditTrail("Update Position" + " " + ex.Message, DateTime.Now.ToString("yyyy-MM-dd"), "Position Module", "User", "0");
                return Problem(ex.GetBaseException().ToString());
            }
        }

        [HttpPost]
        public async Task<IActionResult> delete(DeletionModel deletionModel)
        {

            if (_context.TblPositionModels == null)
            {
                return Problem("Entity set 'ODC_HRISContext.TblPositionModels'  is null.");
            }

            var positionModel = await _context.TblPositionModels.FindAsync(deletionModel.id);
            if (positionModel == null || positionModel.DeleteFlag == 0)
            {
                return Conflict("No records matched!");
            }

            try
            {
                positionModel.DeleteFlag = 0;
                _context.Entry(positionModel).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                string status = "Position successfully deleted";
                dbmet.InsertAuditTrail("Delete Position" + " " + status, DateTime.Now.ToString("yyyy-MM-dd"), "Position Module", deletionModel.deletedBy, "0");

                return Ok("Deletion Successful!");
            }
            catch (Exception ex)
            {
                dbmet.InsertAuditTrail("Delete Position" + " " + ex, DateTime.Now.ToString("yyyy-MM-dd"), "Position Module", deletionModel.deletedBy, "0");
                return Problem(ex.GetBaseException().ToString());
            }
        }

        [HttpPost]
        public async Task<IActionResult> restore(RestorationModel restorationModel)
        {

            if (_context.TblPositionModels == null)
            {
                return Problem("Entity set 'ODC_HRISContext.TblPositionModels'  is null.");
            }

            var positionModel = await _context.TblPositionModels.FindAsync(restorationModel.id);
            if (positionModel == null || positionModel.DeleteFlag == 1)
            {
                return Conflict("No deleted records matched!");
            }

            try
            {

                positionModel.DeleteFlag = 1;
                _context.Entry(positionModel).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                string status = "Position successfully restored";
                dbmet.InsertAuditTrail("Restore Position" + " " + status, DateTime.Now.ToString("yyyy-MM-dd"), "Position Module", restorationModel.restoredBy, "0");

                return Ok("Restoration Successful!");
            }
            catch (Exception ex)
            {
                dbmet.InsertAuditTrail("Restore Position" + " " + ex.Message, DateTime.Now.ToString("yyyy-MM-dd"), "Position Module", restorationModel.restoredBy, "0");
                return Problem(ex.GetBaseException().ToString());
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblPositionModel>> search(int id)
        {
            if (_context.TblPositionModels == null)
            {
                return Problem("Entity set 'ODC_HRISContext.TblPositionModels'  is null.");
            }
            var positionModel = await _context.TblPositionModels.FindAsync(id);

            if (positionModel == null || positionModel.DeleteFlag == 0)
            {
                return Conflict("No records found!");
            }

            string status = "Position successfully searched";
            dbmet.InsertAuditTrail("Search Position" + " " + status, DateTime.Now.ToString("yyyy-MM-dd"), "Position Module", "User", "0");
            return Ok(positionModel);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblPositionModel>>> view()
        {
            if (_context.TblPositionModels == null)
            {
                return Problem("Entity set 'ODC_HRISContext.TblPositionModels'  is null.");
            }
            return await _context.TblPositionModels.Where(positionModel => positionModel.DeleteFlag == 1).ToListAsync();
            string status = "Position successfully viewed";
            dbmet.InsertAuditTrail("View Active Position" + " " + status, DateTime.Now.ToString("yyyy-MM-dd"), "Position Module", "User", "0");
        }
    }
}
