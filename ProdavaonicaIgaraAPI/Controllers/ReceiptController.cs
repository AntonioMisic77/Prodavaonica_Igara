﻿using Microsoft.AspNetCore.Mvc;
using ProdavaonicaIgaraAPI.Data.Articles;
using ProdavaonicaIgaraAPI.Data.Pageing;
using ProdavaonicaIgaraAPI.Data.Receipt;
using ProdavaonicaIgaraAPI.Services.Receipt;

namespace ProdavaonicaIgaraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptController : ControllerBase
    {
        #region properties
        private readonly IReceiptService _receiptService;
        #endregion

        #region ctor
        public ReceiptController(IReceiptService receiptService)
        {
            _receiptService = receiptService;
        }

        #endregion

        #region endpoints

        [HttpGet("{id}")]
        public async Task<ActionResult<ReceiptDto>> GetReceiptAsync(int id)
        {
            var receipt = await _receiptService.GetReceiptAsync(id);

            if (receipt == null)
            {
                return NotFound();
            }

            return Ok(receipt);
        }

        [HttpPost("paged")]
        public async Task<ActionResult<PagedResult<ReceiptDto>>> GetReceiptAsync(QueryParametars parametars)
        {
            var receipts = await _receiptService.GetReceiptsAsync(parametars);

            if (receipts == null)
            {
                return NotFound();
            }

            return Ok(receipts);
            
        }

        [HttpPost]
        public async Task<ActionResult<ReceiptDto>> CreateReceiptAsync(ReceiptDto receiptDto)
        {
           var createdReceipt = await _receiptService.CreateReceiptAsync(receiptDto);

            if (createdReceipt == null)
            {
                return BadRequest();
            }   

            return Ok(createdReceipt);
        }

        [HttpPut]
        public async Task<ActionResult<ReceiptDto>> UpdateReceiptAsync(ReceiptDto receiptDto)
        {
            var updatedReceipt = await _receiptService.UpdateReceiptAsync(receiptDto);

            if (updatedReceipt == null)
            {
                return BadRequest();
            }

            return Ok(updatedReceipt);
            
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ReceiptDto>> DeleteReceipt(int id)
        {
           var deletedReceipt = await _receiptService.DeleteReceipt(id);

            if (deletedReceipt == null)
            {
                return BadRequest();
            }

            return Ok(deletedReceipt);
        }

        #endregion

    }
}
