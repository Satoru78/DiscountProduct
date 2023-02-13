using ApiServer.Model;
using DiscountProduct.Context;
using DiscountProduct.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace ApiServer
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpListener server = new HttpListener();
            server.Prefixes.Add("http://localhost:21456/");

            JsonSerializerOptions options = new JsonSerializerOptions() { Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) };
            server.Start();

            while (true)
            {
                HttpListenerContext context = server.GetContext();
                if (context.Request.HttpMethod == "POST")
                {
                    try
                    {
                        if (context.Request.RawUrl == "/api/products/")
                        {
                            if (context.Request.ContentType == "application/json")
                            {
                                string request = "";
                                byte[] data = new byte[context.Request.ContentLength64];
                                using (Stream stream = context.Request.InputStream)
                                {
                                    stream.Read(data, 0, data.Length);
                                }
                                request = UTF8Encoding.UTF8.GetString(data);
                                var listProduct = JsonSerializer.Deserialize<List<ResponseProduct>>(request);
                                foreach (var product in listProduct)
                                {
                                    Product item = new Product();
                                    item.ID = product.ID;
                                    item.Title = product.Title;
                                    item.IDUnit = product.IDUnit;
                                    item.Count = product.Count;
                                    item.IDDiscount = product.IDDiscount;
                                    item.Manufacturer = product.Manufacturer;
                                    item.Supplier = product.Supplier;
                                    item.IDProductCategory = product.IDProductCategory;
                                    item.QuantitiInStock = product.QuantitiInStock;
                                    item.Description = product.Description;
                                    Data.pde.Product.Add(item);
                                    Data.pde.SaveChanges();
                                }
                                Data.pde.SaveChanges();
                                context.Response.StatusCode = 200;
                                context.Response.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        context.Response.StatusCode = 400;
                        context.Response.Close();

                    }
                }
                else if (context.Request.HttpMethod == "GET")
                {
                    try
                    {
                        if (context.Request.RawUrl == "/api/products/")
                        {
                            var productList = Data.pde.Product.ToList();
                            string response = JsonSerializer.Serialize(Data.pde.Product.ToList().ConvertAll(c => new ResponseProduct(c)), options);
                            byte[] data = Encoding.UTF8.GetBytes(response);
                            context.Response.ContentType = "application/json;charset=utf-8";
                            using (Stream stream = context.Response.OutputStream)
                            {
                                context.Response.StatusCode = 200;
                                stream.Write(data, 0, data.Length);
                            }
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        context.Response.StatusCode = 400;
                        context.Response.Close();
                    }
                }
                else if (context.Request.HttpMethod == "DELETE")
                {
                    try
                    {

                        if (context.Request.QueryString.Count == 1)
                        {
                            if (context.Request.QueryString.Keys[0] == "id")
                            {
                                int id = Convert.ToInt32(context.Request.QueryString.Get(0));
                                var currentProduct = Data.pde.Product.FirstOrDefault(c => c.ID == id);
                                if (currentProduct != null)
                                {
                                    Data.pde.Product.Remove(currentProduct);
                                    Data.pde.SaveChanges();
                                    context.Response.StatusCode = 200;
                                    context.Response.Close();
                                }
                                else
                                {
                                    throw new Exception();
                                }
                            }
                        }

                    }
                    catch
                    {
                        context.Response.StatusCode = 400;
                        context.Response.Close();
                    }
                }
            }
        }
    }
}
