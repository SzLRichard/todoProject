using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UpdateResponseDTO
    {
        public bool isUpdateSuccessful { get; set; }

        public UpdateResponseDTO(bool success) {
            isUpdateSuccessful = success;
        }
    }
}
